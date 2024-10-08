using OctoPrint.NET.Rest.Models.Request;
using OctoPrint.NET.Rest.Models.Response;

namespace OctoPrint.NET.Rest.Clients.Interfaces;

/// <summary>
/// Client responsible for getting and updating the OctoPrint connection.
/// </summary>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/connection.html">the OctoPrint Documentation</see> for more details.
/// </remarks>
public interface IConnectionClient
{
    /// <summary>
    /// Gets the current connection status and settings.
    /// </summary>
    /// 
    /// <returns>
    /// The current connection status and settings from OctoPrint, as a <see cref="ConnectionResponse"/>.
    /// </returns>
    Task<ConnectionResponse> GetConnection();

    /// <summary>
    /// Issue a connection command to OctoPrint.
    /// </summary>
    /// 
    /// <param name="request">
    /// The <see cref="ConnectionRequest"/> command information.
    /// </param>
    Task IssueConnectionCommand(ConnectionRequest request);
}