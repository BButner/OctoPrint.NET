using OctoPrint.NET.Rest.Models.Response;

namespace OctoPrint.NET.Rest.Clients.Interfaces;

/// <summary>
/// Client responsible for retrieving the OctoPrint version.
/// </summary>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/version.html">OctoPrint Documentation</see> for more details.
/// </remarks>
public interface IVersionClient
{
    /// <summary>
    /// Gets the current version information.
    /// </summary>
    /// 
    /// <returns>
    /// The current version information as a <see cref="VersionResponse"/>.
    /// </returns>
    Task<VersionResponse> GetVersion();
}