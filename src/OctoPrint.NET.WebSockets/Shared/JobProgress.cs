namespace OctoPrint.NET.WebSockets.Shared;

/// <summary>
/// Job progress.
/// </summary>
public class JobProgress
{
    /// <summary>
    /// The current completion percentage.
    /// </summary>
    public double? Completion { get; init; }

    /// <summary>
    /// The current file pos.
    /// </summary>
    public int? FilePos { get; init; }

    /// <summary>
    /// How long the print has been running in seconds.
    /// </summary>
    public uint? PrintTime { get; init; }

    /// <summary>
    /// How long the print has left in seconds.
    /// </summary>
    public uint? PrintTimeLeft { get; init; }

    /// <summary>
    /// The origin of the print time left.
    /// </summary>
    public string? PrintTimeLeftOrigin { get; init; }
}