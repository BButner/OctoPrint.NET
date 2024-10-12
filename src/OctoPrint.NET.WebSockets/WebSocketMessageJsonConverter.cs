using System.Text.Json;
using System.Text.Json.Serialization;
using OctoPrint.NET.Json;
using OctoPrint.NET.WebSockets.Current;
using OctoPrint.NET.WebSockets.Events;

namespace OctoPrint.NET.WebSockets;

/// <summary>
/// <see cref="JsonConverter{T}"/> for the incoming <see cref="OctoPrintWebSocketMessageReceived"/> messages.
/// </summary>
public class WebSocketMessageJsonConverter : JsonConverter<OctoPrintWebSocketMessageReceived>
{
    /// <inheritdoc/>
    public override OctoPrintWebSocketMessageReceived? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        OctoPrintWebSocketMessageReceived? messageReceived = null;

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

        if (outerDiscrim.Equals("current", StringComparison.CurrentCultureIgnoreCase))
        {
            reader.Read();
            messageReceived = OctoPrintJson.Deserialize<CurrentMessage>(ref reader);

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject && reader.CurrentDepth == 0)
                {
                    return messageReceived;
                }
            }
        }
        else
        {
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

                messageReceived = outerDiscrim switch
                {
                    "event" => innerDiscrim switch
                    {
                        "capturedone" => OctoPrintJson.Deserialize<CaptureDoneEvent>(ref reader),
                        "capturestart" => OctoPrintJson.Deserialize<CaptureStartEvent>(ref reader),
                        "zchange" => OctoPrintJson.Deserialize<ZChangeEvent>(ref reader),
                        _ => null,
                    },
                    _ => null,
                };
            }
        }

        return messageReceived;
    }

    public override void Write(Utf8JsonWriter writer, OctoPrintWebSocketMessageReceived value,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private T? Deserialize<T>(string contents) =>
        JsonSerializer.Deserialize<T>(contents, OctoPrintJson.DefaultSerializerOptions);
}