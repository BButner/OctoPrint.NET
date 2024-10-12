using System.Text.Json;
using System.Text.Json.Serialization;

namespace OctoPrint.NET.Json.Models.Shared;

/// <summary>
/// Current printer temperatures.
/// </summary>
[JsonConverter(typeof(PrinterTemperaturesJsonConverter))]
public class PrinterTemperatures
{
    /// <summary>
    /// The time of the temperature readings.
    /// </summary>
    public int Time { get; set; }

    /// <summary>
    /// The dynamic temperature data points.
    /// </summary>
    // TODO: We need a custom deserializer for this that will translate the dynamic dictionary values into this dictionary.
    public Dictionary<string, TemperatureData> DataPoints { get; } = new();
}

/// <summary>
/// Custom JSON converter for <see cref="PrinterTemperatures"/>.
/// </summary>
public class PrinterTemperaturesJsonConverter : JsonConverter<PrinterTemperatures>
{
    /// <inheritdoc/>
    public override PrinterTemperatures? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject && reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        var temps = new PrinterTemperatures();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return temps;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case not null when propertyName.ToLower().Equals(nameof(PrinterTemperatures.Time).ToLower()):
                        temps.Time = reader.GetInt32();
                        break;
                    case not null:
                        var dataPoint =
                            JsonSerializer.Deserialize<TemperatureData>(ref reader,
                                OctoPrintJson.DefaultSerializerOptions);
                        if (dataPoint is not null)
                        {
                            temps.DataPoints.Add(propertyName, dataPoint);
                        }

                        break;
                }
            }
        }

        throw new JsonException();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, PrinterTemperatures value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}