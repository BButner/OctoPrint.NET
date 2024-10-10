namespace OctoPrint.NET.WebSockets.Shared;

/// <summary>
/// Temperature data.
/// </summary>
public class TemperatureData
{
    /// <summary>
    /// The actual current temperature value.
    /// </summary>
    public double? Actual { get; init; }

    /// <summary>
    /// The current temperature target.
    /// </summary>
    public double? Target { get; init; }
}