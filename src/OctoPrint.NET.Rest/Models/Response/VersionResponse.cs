using System.Text.Json;

namespace OctoPrint.NET.Rest.Models.Response;

/// <summary>
/// Response from the backend for the version.
/// </summary>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/version.html#get--api-version">OctoPrint Documentation</see> for more details.
/// </remarks>
public class VersionResponse
{
    /// <summary>
    /// The API Version.
    /// </summary>
    public required string Api { get; set; }

    /// <summary>
    /// The Server Version.
    /// </summary>
    public required string Server { get; set; }

    /// <summary>
    /// The Server Version including the prefix OctoPrint.
    /// </summary>
    public required string Text { get; set; }

    /// <inheritdoc/>
    public override string ToString() =>
        JsonSerializer.Serialize(this);
}