using OctoPrint.NET.Rest.Models.Response;

namespace OctoPrint.NET.Rest.Clients.Interfaces;

/// <summary>
/// Client responsible for retrieving the OctoPrint server information.
/// </summary>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/server.html">the OctoPrint Docs</see> for more details.
/// </remarks>
public interface IServerClient
{
    /// <summary>
    /// Gets the current server information.
    /// </summary>
    /// 
    /// <returns>
    /// The current server information as a <see cref="ServerResponse"/>.
    /// </returns>
    Task<ServerResponse> GetServerInformation();
}