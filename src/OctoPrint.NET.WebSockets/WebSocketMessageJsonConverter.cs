using System.Text.Json;
using System.Text.Json.Serialization;
using OctoPrint.NET.Json;
using OctoPrint.NET.WebSockets.Current;
using OctoPrint.NET.WebSockets.Events;
using OctoPrint.NET.WebSockets.Plugin;

namespace OctoPrint.NET.WebSockets;

/// <summary>
/// <see cref="JsonConverter{T}"/> for the incoming <see cref="OctoPrintWebSocketMessage"/> messages.
/// </summary>
public class WebSocketMessageJsonConverter : JsonConverter<OctoPrintWebSocketMessage>
{
    /// <inheritdoc/>
    public override OctoPrintWebSocketMessage? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        reader.Read();
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException();
        }

        var outerDiscrim = reader.GetString()?.ToLower();
        if (outerDiscrim is null)
        {
            throw new JsonException();
        }

        return outerDiscrim switch
        {
            "current" => HandleGeneric<CurrentMessage>(ref reader),
            "plugin" => HandleGeneric<OctoPrintPluginMessage>(ref reader),
            "event" => HandleEvent(ref reader),
            _ => null,
        };
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, OctoPrintWebSocketMessage value,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private OctoPrintWebSocketMessage? HandleGeneric<T>(ref Utf8JsonReader reader) where T : OctoPrintWebSocketMessage
    {
        reader.Read();
        var message = OctoPrintJson.Deserialize<T>(ref reader);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject && reader.CurrentDepth == 0)
            {
                return message;
            }
        }

        return null;
    }

    private OctoPrintWebSocketMessage? HandleEvent(ref Utf8JsonReader reader)
    {
        OctoPrintWebSocketMessage? messageReceived = null;

        while (reader.Read())
        {
            if (reader.TokenType != JsonTokenType.PropertyName || reader.CurrentDepth != 2) continue;

            var innerDiscrim = reader.GetString()?.ToLower();

            if (innerDiscrim == "type")
            {
                reader.Read();
                if (reader.TokenType == JsonTokenType.String)
                {
                    innerDiscrim = reader.GetString()?.ToLower();
                    reader.Read();
                }
            }

            messageReceived = innerDiscrim switch
            {
                "capturedone" => OctoPrintJson.Deserialize<CaptureDoneEvent>(ref reader),
                "capturestart" => OctoPrintJson.Deserialize<CaptureStartEvent>(ref reader),
                "zchange" => OctoPrintJson.Deserialize<ZChangeEvent>(ref reader),
                _ => null,
            };
        }

        return messageReceived;
    }
}