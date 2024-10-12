using OctoPrint.NET.WebSockets.Current;

namespace OctoPrint.NET.WebSockets.Shared;

/// <summary>
/// An OctoPrint file.
/// </summary>
public class JobFile
{
    /// <summary>
    /// The name of the file, if there is one.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// The path of the file, if there is one.
    /// </summary>
    public string? Path { get; init; }

    /// <summary>
    /// The display of the file, if there is one.
    /// </summary>
    public string? Display { get; init; }

    /// <summary>
    /// The origin fo the file, if there is one.
    /// </summary>
    public string? Origin { get; init; }

    /// <summary>
    /// The size of the file in bytes, if there is one.
    /// </summary>
    public int? Size { get; init; }

    /// <summary>
    /// The date of the file as a unix epoch timestamp, if there is one.
    /// </summary>
    public int? Date { get; init; }
}