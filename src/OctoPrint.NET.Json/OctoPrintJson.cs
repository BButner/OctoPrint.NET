using System.Text.Json;
using System.Text.Json.Serialization;

namespace OctoPrint.NET.Json;

/// <summary>
/// Static options/helpers for OctoPrint JSON.
/// </summary>
public static class OctoPrintJson
{
    /// <summary>
    /// The default <see cref="JsonSerializerOptions"/> to be used on all requests.
    /// </summary>
    public static JsonSerializerOptions DefaultSerializerOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower)
        },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}