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

    /// <summary>
    /// Default method to use for deserializing.
    /// </summary>
    public static T? Deserialize<T>(string contents) =>
        JsonSerializer.Deserialize<T>(contents, DefaultSerializerOptions);

    /// <summary>
    /// Deserialize an instance of <see cref="T"/> from a <see cref="Utf8JsonReader"/>.
    /// </summary>
    /// 
    /// <param name="reader">
    /// The reader to read.
    /// </param>
    /// 
    /// <typeparam name="T">
    /// The type to deserialize the JSON value into.
    /// </typeparam>
    /// 
    /// <returns>
    /// A <see cref="T"/> representation of the JSON value.
    /// </returns>
    public static T? Deserialize<T>(ref Utf8JsonReader reader) =>
        JsonSerializer.Deserialize<T>(ref reader, DefaultSerializerOptions);
}