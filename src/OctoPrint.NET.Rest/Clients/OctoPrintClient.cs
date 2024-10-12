using OctoPrint.NET.Rest.Clients.Interfaces;
using OctoPrint.NET.Rest.Requester;
using OctoPrint.NET.WebSockets;

namespace OctoPrint.NET.Rest.Clients;

/// <summary>
/// Client used to interact with the OctoPrint instance.
/// </summary>
public class OctoPrintClient : IOctoPrintClient
{
    /// <summary>
    /// Creates a new instance of the <see cref="OctoPrintClient"/>, used to
    /// interface with the OctoPrint server instance.
    /// </summary>
    /// 
    /// <param name="hostname">
    /// The Hostname/URL of the OctoPrint instance.
    /// </param>
    /// <param name="port">
    /// The port that the OctoPrint server is available on.
    /// </param>
    /// <param name="apiKey">
    /// The API Key used to authorize requests.
    /// </param>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/general.html#authorization">the OctoPrint Docs</see>
    /// for information on how to get your ApiKey.
    /// </remarks>
    public OctoPrintClient(
        string hostname,
        string apiKey,
        int port = 80
    )
    {
        Hostname = hostname;
        ApiKey = apiKey;
        Port = port;

        _restClient = new OctoPrintRequester(
            new UriBuilder(hostname)
            {
                Port = port
            }.Uri,
            ApiKey
        );

        Connection = new ConnectionClient(_restClient);
        Server = new ServerClient(_restClient);
        Version = new VersionClient(_restClient);
        WebSockets = new OctoPrintWebSocketClient(hostname, port, apiKey);
    }

    /// <inheritdoc/>
    public string Hostname { get; init; }

    /// <inheritdoc/>
    public string ApiKey { get; init; }

    /// <inheritdoc/>
    public int Port { get; init; }

    /// <inheritdoc/>
    public IConnectionClient Connection { get; init; }

    /// <inheritdoc/>
    public IServerClient Server { get; init; }

    /// <inheritdoc/>
    public IVersionClient Version { get; init; }

    public OctoPrintWebSocketClient WebSockets { get; init; }

    private readonly IApiRequester _restClient;
}