namespace OctoPrint.NET.WebSockets.Events;

/// <summary>
/// Event raised when the printer state changes.
/// </summary>
public class PrinterStateChangedEvent : OctoPrintWebSocketEvent
{
    /// <summary>
    /// The event state id.
    /// </summary>
    public required PrinterStateChangedId StateId { get; init; }

    /// <summary>
    /// The state string.
    /// </summary>
    public required string StateString { get; init; }
}

/// <summary>
/// Enum representing the printer state changed id.
/// </summary>
public enum PrinterStateChangedId
{
    OpenSerial,
    DetectSerial,
    DetectBaudrate,
    Connecting,
    Operational,
    Starting,
    Printing,
    Paused,
    Pausing,
    Resuming,
    Finishing,
    Closed,
    Error,
    ClosedWithError,
    TransferingFile,
    Cancelling,
    Offline,
    Unknown,
    None
}