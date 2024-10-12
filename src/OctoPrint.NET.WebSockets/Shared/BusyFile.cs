namespace OctoPrint.NET.WebSockets.Shared;

public class BusyFile
{
    /// <summary>
    /// The origin.
    /// </summary>
    public required string Origin { get; init; }

    /// <summary>
    /// The path.
    /// </summary>
    public required string Path { get; init; }
}