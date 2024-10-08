using System.Text.Json;
using System.Text.Json.Serialization;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Models.Response;

/// <summary>
/// Response from the backend with the server information.
/// </summary>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/server.html#get--api-server">the OctoPrint Docs</see> for more details.
/// </remarks>
public class ServerResponse
{
    /// <summary>
    /// Gets the server version.
    /// </summary>
    public required string Version { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(ServerResponseSafeModeConverter))]
    public SafeMode SafeMode { get; set; }
}

/// <summary>
/// The possible safe mode enum responses from OctoPrint.
/// </summary>
public enum SafeMode
{
    False,
    Flag,
    IncompleteStartup,
    Settings,
}

class ServerResponseSafeModeConverter : JsonConverter<SafeMode>
{
    /// <inheritdoc/>
    public override SafeMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.False:
                return SafeMode.False;
            case JsonTokenType.String:
            {
                var value = reader.GetString();

                if (value is null) throw new NullReferenceException();

                return value switch
                {
                    "flag" => SafeMode.Flag,
                    "incomplete_startup" => SafeMode.IncompleteStartup,
                    "settings" => SafeMode.Settings,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <inheritdoc/>
    ///
    /// We throw, as this is not a property that will ever be sent to the backend.
    public override void Write(Utf8JsonWriter writer, SafeMode value, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}