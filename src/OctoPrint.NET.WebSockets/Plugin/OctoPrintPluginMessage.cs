using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace OctoPrint.NET.WebSockets.Plugin;

/// <summary>
/// WebSocket message from an OctoPrint plugin.
/// </summary>
[JsonConverter(typeof(PluginMessageJsonConverter))]
public class OctoPrintPluginMessage : OctoPrintWebSocketMessage
{
    /// <summary>
    /// The name of the plugin that sent the message.
    /// </summary>
    public required string Plugin { get; init; }

    /// <summary>
    /// The dynamic <see cref="JsonObject"/> data sent from the plugin.
    /// </summary>
    public required JsonObject Data { get; init; }
}

/// <summary>
/// <see cref="JsonConverter{T}"/> for a <see cref="OctoPrintPluginMessage"/>
/// </summary>
public class PluginMessageJsonConverter : JsonConverter<OctoPrintPluginMessage>
{
    /// <inheritdoc/>
    public override OctoPrintPluginMessage? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        string? pluginName = null;
        JsonObject? pluginData = null;

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.EndObject when pluginName is not null && pluginData is not null:
                    return new OctoPrintPluginMessage
                    {
                        Plugin = pluginName,
                        Data = pluginData,
                    };
                case JsonTokenType.PropertyName:
                {
                    var propName = reader.GetString()?.ToLower();
                    reader.Read();

                    switch (propName)
                    {
                        case not null when propName.Equals(nameof(OctoPrintPluginMessage.Plugin).ToLower()):
                            pluginName = reader.GetString();
                            break;
                        case not null when propName.Equals(nameof(OctoPrintPluginMessage.Data).ToLower()):
                            pluginData = JsonSerializer.Deserialize<JsonObject>(ref reader);
                            break;
                    }

                    break;
                }
            }
        }

        throw new JsonException();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, OctoPrintPluginMessage value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}