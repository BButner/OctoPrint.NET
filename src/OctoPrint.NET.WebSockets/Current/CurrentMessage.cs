using OctoPrint.NET.Json.Models.Shared;
using OctoPrint.NET.WebSockets.Shared;

namespace OctoPrint.NET.WebSockets.Current;

/// <summary>
/// Current status message received from the webhook.
/// </summary>
public class CurrentMessage : OctoPrintWebSocketMessage
{
    /// <summary>
    /// The current printer state.
    /// </summary>
    public required PrinterState State { get; init; }

    /// <summary>
    /// The current job information.
    /// </summary>
    public required JobInformation Job { get; init; }

    /// <summary>
    /// The current Z axis location.
    /// </summary>
    public double? CurrentZ { get; init; }

    /// <summary>
    /// The current job progress.
    /// </summary>
    public required JobProgress Progress { get; init; }

    /// <summary>
    /// The current resends.
    /// </summary>
    public required Resends Resends { get; init; }

    /// <summary>
    /// The current server time as a timestamp with decimal precision.
    /// </summary>
    public required double ServerTime { get; init; }

    /// <summary>
    /// Temperature readings.
    /// </summary>
    public required IEnumerable<PrinterTemperatures> Temps { get; init; }

    /// <summary>
    /// Busy files, if there are any.
    /// </summary>
    public IEnumerable<BusyFile>? BusyFiles { get; init; }

    /// <summary>
    /// Markings.
    /// </summary>
    public required IEnumerable<Marking> Markings { get; init; }

    /// <summary>
    /// Log entries.
    /// </summary>
    public required IEnumerable<string> Logs { get; init; }

    /// <summary>
    /// Messages.
    /// </summary>
    public required IEnumerable<string> Messages { get; init; }
}