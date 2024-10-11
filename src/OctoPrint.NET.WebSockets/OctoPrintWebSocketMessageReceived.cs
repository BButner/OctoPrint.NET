using System.Text.Json.Serialization;

namespace OctoPrint.NET.WebSockets;

/// <summary>
/// Base class for any OctoPrint WebHook Message that we receive.
/// </summary>
[JsonConverter(typeof(WebSocketMessageJsonConverter))]
public abstract class OctoPrintWebSocketMessageReceived
{
}