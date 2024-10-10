namespace OctoPrint.NET.WebSockets.Current;

/// <summary>
/// Current state, part of the <see cref="CurrentMessage"/>.
/// </summary>
public class CurrentState
{
    /// <summary>
    /// The state text.
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// The current state flags.
    /// </summary>
    public required CurrentStateFlags Flags { get; init; }

    /// <summary>
    /// The error text, if there is one.
    /// </summary>
    public string? Error { get; init; }
}

/// <summary>
/// Current state flags.
/// </summary>
public class CurrentStateFlags
{
    public required bool Operational { get; init; }

    public required bool Printing { get; init; }

    public required bool Cancelling { get; init; }

    public required bool Pausing { get; init; }

    public required bool Resuming { get; init; }

    public required bool Finishing { get; init; }

    public required bool ClosedOrError { get; init; }

    public required bool Error { get; init; }

    public required bool Paused { get; init; }

    public required bool Ready { get; init; }

    public required bool SdReady { get; init; }
}