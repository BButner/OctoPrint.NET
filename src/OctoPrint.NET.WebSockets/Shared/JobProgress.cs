namespace OctoPrint.NET.WebSockets.Shared;

/// <summary>
/// Job progress.
/// </summary>
public class JobProgress
{
    /// <summary>
    /// Percentage of completion of the current print job
    /// </summary>
    public double? Completion { get; init; }

    /// <summary>
    /// Current position in the file being printed, in bytes from the beginning.
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