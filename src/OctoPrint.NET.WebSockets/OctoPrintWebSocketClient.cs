using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OctoPrint.NET.WebSockets;

public class OctoPrintWebSocketClient
{
    public OctoPrintWebSocketClient(string hostname, int port, string apiKey)
    {
        _hostname = hostname;
        _port = port;
        _uri = new UriBuilder("ws", hostname, port, "/sockjs/websocket").Uri;
        _apiKey = apiKey;

        _connection = new ClientWebSocket();

        _ = Receive();
    }

    public Task Connection => _connectionTask.Task;

    private async Task Authenticate()
    {
        var tempClient = new HttpClient()
        {
            BaseAddress = new UriBuilder("http", _hostname, _port).Uri,
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Bearer", _apiKey),
            },
        };

        var content = new StringContent(JsonSerializer.Serialize(new { passive = true }), Encoding.UTF8,
            "application/json");

        var res = await tempClient.PostAsync(new Uri("/api/login", UriKind.Relative),
            content, _connectionToken);

        var responseContent =
            JsonSerializer.Deserialize<JsonNode>(await res.Content.ReadAsStringAsync(_connectionToken));
        if (responseContent is null) return;

        var name = responseContent["name"];
        var session = responseContent["session"];

        if (name is null || session is null) return;

        await _connection.SendAsync(
            new ArraySegment<byte>(Encoding.UTF8.GetBytes($"{{ \"auth\": \"{name}:{session}\" }}")),
            WebSocketMessageType.Binary, true,
            _connectionToken
        );
    }

    private async Task Receive()
    {
        await _connection.ConnectAsync(_uri, _connectionToken);

        await Authenticate();

        var buffer = new byte[8192];

        while (!_connectionToken.IsCancellationRequested)
        {
            using var outputStream = new MemoryStream(8192);
            WebSocketReceiveResult? result;

            do
            {
                result = await _connection.ReceiveAsync(new ArraySegment<byte>(buffer), _connectionToken);
                if (result.MessageType != WebSocketMessageType.Close)
                    await outputStream.WriteAsync(buffer, 0, result.Count, _connectionToken);
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
        var reader = new StreamReader(inputStream);

        Console.WriteLine(await reader.ReadToEndAsync(_connectionToken));
    }

    private string _hostname;
    private int _port;
    private Uri _uri;
    private string _apiKey;
    private CancellationToken _connectionToken = new();
    private TaskCompletionSource _connectionTask = new();
    private ClientWebSocket _connection;
}