using OctoPrint.NET.WebSockets.Current;

namespace OctoPrint.NET.WebSockets.Shared;

/// <summary>
/// The current job, part of the <see cref="CurrentMessage"/>.
/// </summary>
public class JobInformation
{
    /// <summary>
    /// The current <see cref="JobFile"/> loaded. The file properties will be null if there is no job running.
    /// </summary>
    public required JobFile File { get; init; }

    /// <summary>
    /// The estimated print time in seconds, if there is currently a print loaded.
    /// </summary>
    public uint? EstimatedPrintTime { get; init; }

    /// <summary>
    /// The average print time in seconds, if there is one.
    /// </summary>
    public uint? AveragePrintTime { get; init; }

    /// <summary>
    /// The last print time as a unix epoch timestamp, if there is one.
    /// </summary>
    public uint? LastPrintTime { get; init; }

    /// <summary>
    /// The user who started the job, if there is one.
    /// </summary>
    public string? User { get; init; }
}