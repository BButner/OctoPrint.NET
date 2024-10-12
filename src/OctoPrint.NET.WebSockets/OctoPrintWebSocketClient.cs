using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Reactive.Subjects;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using OctoPrint.NET.Json;
using OctoPrint.NET.WebSockets.Current;
using OctoPrint.NET.WebSockets.Events;

namespace OctoPrint.NET.WebSockets;

/// <summary>
/// WebSocket client to connect to OctoPrint.
/// </summary>
public class OctoPrintWebSocketClient
{
    /// <summary>
    /// Event raised when the client successfully connects and authenticates.
    /// </summary>
    public event EventHandler? ClientConnected;

    /// <summary>
    /// Creates a new <see cref="OctoPrintWebSocketClient"/>.
    /// </summary>
    /// 
    /// <param name="hostname">
    /// The hostname of the OctoPrint instance.
    /// </param>
    /// <param name="port">
    /// The port of the OctoPrint instance.
    /// </param>
    /// <param name="apiKey">
    /// The API Key used to authorize requests.
    /// </param>
    public OctoPrintWebSocketClient(string hostname, int port, string apiKey)
    {
        _restUri = new UriBuilder("http", hostname, port).Uri;
        _webSocketUri = new UriBuilder("ws", hostname, port, "/sockjs/websocket").Uri;
        _apiKey = apiKey;

        _connection = new ClientWebSocket();
    }

    /// <summary>
    /// Task that lives for the duration of the WebSocket connection.
    /// </summary>
    public Task Connection => _connectionTask.Task;

    /// <summary>
    /// Observes the incoming messages from the OctoPrint WebSocket server.
    /// </summary>
    public IObservable<OctoPrintWebSocketMessage> ReceivedMessages => _messageReceivedSubject;

    /// <summary>
    /// Method used to initialize the connection to the WebSocket server.
    /// </summary>
    public async Task Initialize()
    {
        await _connection.ConnectAsync(_webSocketUri, _connectionToken);

        _ = Receive();

        await Authenticate();

        ClientConnected?.Invoke(this, EventArgs.Empty);
    }

    private async Task Authenticate()
    {
        var tempClient = new HttpClient
        {
            BaseAddress = _restUri,
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", _apiKey),
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(new { passive = true }),
            Encoding.UTF8,
            "application/json"
        );

        var res = await tempClient.PostAsync(
            _authEndpoint,
            content, _connectionToken
        );

        var responseContent =
            JsonSerializer.Deserialize<JsonNode>(await res.Content.ReadAsStringAsync(_connectionToken));

        if (responseContent is null)
        {
            throw new AuthenticationException("Could not authenticate with WebSocket backend, response was empty.");
        }

        var name = responseContent["name"];
        var session = responseContent["session"];

        if (name is null || session is null)
        {
            throw new AuthenticationException(
                "Could not authenticate with WebSocket backend, name or session was null.");
        }

        await _connection.SendAsync(
            new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{{ \"auth\": \"{name}:{session}\" }}")),
            WebSocketMessageType.Binary, true,
            _connectionToken
        );
    }

    private async Task Receive()
    {
        var buffer = new byte[8192];

        while (!_connectionToken.IsCancellationRequested)
        {
            using var outputStream = new MemoryStream(8192);
            WebSocketReceiveResult? result;

            do
            {
                result = await _connection.ReceiveAsync(new ArraySegment<byte>(buffer), _connectionToken);
                if (result.MessageType != WebSocketMessageType.Close)
                    await outputStream.WriteAsync(buffer.AsMemory(0, result.Count), _connectionToken);
            } while (!result?.EndOfMessage ?? false);

            if (result?.MessageType == WebSocketMessageType.Close)
            {
                _connectionTask.TrySetResult();
                break;
            }

            outputStream.Position = 0;
            await ResponseReceived(outputStream);
        }
    }

    private async Task ResponseReceived(Stream inputStream)
    {
        var contents = await new StreamReader(inputStream).ReadToEndAsync(_connectionToken);

        try
        {
            var message = OctoPrintJson.Deserialize<OctoPrintWebSocketMessage>(contents);

            if (message is null)
            {
                Console.WriteLine(contents);
            }
            else
            {
                Console.WriteLine($"Got message type: {message.GetType()}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception Deserializing Message: {ex}");
        }
    }

    private readonly string _apiKey;

    private readonly Uri _restUri;
    private readonly Uri _webSocketUri;
    private readonly Uri _authEndpoint = new("/api/login", UriKind.Relative);

    private readonly CancellationToken _connectionToken = new();
    private readonly TaskCompletionSource _connectionTask = new();
    private readonly ClientWebSocket _connection;

    private readonly Subject<OctoPrintWebSocketMessage> _messageReceivedSubject = new();
}