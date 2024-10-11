namespace OctoPrint.NET.WebSockets.Events;

/// <summary>
/// Event fired when the client is successfully authenticated.
/// </summary>
public class ClientAuthedEvent : OctoPrintWebSocketEvent
{
    /// <summary>
    /// Gets the username used during authentication.
    /// </summary>
    public required string Username { get; init; }

    /// <summary>
    /// Gets the remote address.
    /// </summary>
    public required string RemoteAddress { get; init; }
}