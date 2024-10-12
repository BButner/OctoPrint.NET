namespace OctoPrint.NET.WebSockets.Shared;

public class Marking
{
    public required string Type { get; init; }

    public required string Label { get; init; }

    public required double Time { get; init; }
}