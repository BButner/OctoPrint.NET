using System.Text.Json.Nodes;

namespace OctoPrint.NET.WebSockets.Events;

/// <summary>
/// Static class to handle deserializing events.
/// </summary>
public static class EventDeserializer
{
    public static async Task<OctoPrintWebHookEvent?> TryDeserializeEvent(string type, JsonNode payload)
    {
        return type switch
        {
            "PrinterStateChanged" => payload.GetValue<PrinterStateChangedEvent>(),
            _ => null,
        };
    }
}