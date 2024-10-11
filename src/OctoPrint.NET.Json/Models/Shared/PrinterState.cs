namespace OctoPrint.NET.Json.Models.Shared;

/// <summary>
/// Current Printer State.
/// </summary>
public class PrinterState
{
    /// <summary>
    /// The state text.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// The current state flags.
    /// </summary>
    public required PrinterStateFlags Flags { get; init; }

    /// <summary>
    /// The error text, if there is one.
    /// </summary>
    public string? Error { get; init; }
}

/// <summary>
/// Current state flags.
/// </summary>
public class PrinterStateFlags
{
    /// <summary>
    /// True if the printer is operational, false otherwise.
    /// </summary>
    public required bool Operational { get; init; }

    /// <summary>
    /// True if the printer is currently printing, false otherwise.
    /// </summary>
    public required bool Printing { get; init; }

    /// <summary>
    /// True if the printer is currently printing and in the process of cancelling, false otherwise.
    /// </summary>
    public required bool Cancelling { get; init; }

    /// <summary>
    /// True if the printer is currently printing and in the process of pausing, false otherwise.
    /// </summary>
    public required bool Pausing { get; init; }

    /// <summary>
    /// True if the printer is currently in the process of resuming, false otherwise.
    /// </summary>
    public required bool Resuming { get; init; }

    /// <summary>
    /// True if the printer is finishing, false otherwise.
    /// </summary>
    public required bool Finishing { get; init; }

    /// <summary>
    /// True if the printer is disconnected (possibly due to an error), false otherwise.
    /// </summary>
    public required bool ClosedOrError { get; init; }

    /// <summary>
    /// True if an unrecoverable error occurred, false otherwise.
    /// </summary>
    public required bool Error { get; init; }

    /// <summary>
    /// True if the printer is currently paused, false otherwise.
    /// </summary>
    public required bool Paused { get; init; }

    /// <summary>
    /// True if the printer is operational and no data is currently being streamed to SD, so ready to receive instructions.
    /// </summary>
    public required bool Ready { get; init; }

    /// <summary>
    /// True if the printers SD card is available and initialized, false otherwise.
    /// </summary>
    public required bool SdReady { get; init; }
}