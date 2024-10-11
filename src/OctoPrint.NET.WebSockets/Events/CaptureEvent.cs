namespace OctoPrint.NET.WebSockets.Events;

/// <summary>
/// Base class for a webcam capture.
/// </summary>
public abstract class CaptureEvent
{
    /// <summary>
    /// The file path for the capture.
    /// </summary>
    public required string File { get; init; }
}

/// <summary>
/// Event fired when a webcam capture starts.
/// </summary>
public class CaptureStartEvent : CaptureEvent
{
}

/// <summary>
/// Event fired when a webcam capture ends.
/// </summary>
public class CaptureDoneEvent : CaptureEvent
{
}