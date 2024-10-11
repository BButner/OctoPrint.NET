using System.Text.Json;
using System.Text.Json.Serialization;
using OctoPrint.NET.Json;
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
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        reader.Read();
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException();
        }

        var outerDiscrim = reader.GetString();
        if (outerDiscrim is null)
        {
            throw new JsonException();
        }

        while (reader.Read())
        {
            Console.WriteLine($"Reading: {reader.TokenType}");

            if (reader.TokenType is JsonTokenType.PropertyName)
            {
                Console.WriteLine($"Found Property: {reader.TokenType}");
            }
        }

        // reader.Read();
        // if (outerDiscrim.Equals("event", StringComparison.CurrentCultureIgnoreCase))
        // {
        //     using var doc = JsonDocument.ParseValue(ref reader);
        //     var eventType = doc.RootElement.GetProperty("type").GetString()?.ToLower();
        //
        //     switch (eventType)
        //     {
        //         case "zchange":
        //             while (reader.Read())
        //             {
        //             }
        //             return Deserialize<ZChangeEvent>(doc.RootElement.GetProperty("payload").ToString());
        //         default:
        //             Console.WriteLine(doc.RootElement.GetProperty("payload"));
        //             throw new JsonException($"Unknown event type: {eventType}");
        //     }
        // }
        // else
        // {
        //     while (reader.Read())
        //     {
        //     }
        // }


        return null;
    }

    public override void Write(Utf8JsonWriter writer, OctoPrintWebSocketMessageReceived value,
        JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    private T? Deserialize<T>(string contents) =>
        JsonSerializer.Deserialize<T>(contents, OctoPrintJson.DefaultSerializerOptions);
}