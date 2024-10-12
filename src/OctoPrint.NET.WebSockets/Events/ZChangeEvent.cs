namespace OctoPrint.NET.WebSockets.Events;

/// <summary>
/// Event raised when the current Z Axis height changes.
/// </summary>
public class ZChangeEvent : OctoPrintWebSocketEvent
{
    /// <summary>
    /// The new Z Axis height.
    /// </summary>
    public required double New { get; init; }

    /// <summary>
    /// The old Z Axis height.
    /// </summary>
    public required double Old { get; init; }
}