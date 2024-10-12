namespace OctoPrint.NET.WebSockets.Shared;

/// <summary>
/// Resends.
/// </summary>
public class Resends
{
    /// <summary>
    /// Number of resend requests received since connecting.
    /// </summary>
    public required int Count { get; init; }

    /// <summary>
    /// Number of transmitted lines since connecting.
    /// </summary>
    public required int Transmitted { get; init; }

    /// <summary>
    /// Percentage of resend requests vs transmitted lines. Value between 0 and 100.
    /// </summary>
    public required int Ratio { get; init; }
}