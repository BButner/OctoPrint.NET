using OctoPrint.NET.Rest.Clients.Interfaces;
using OctoPrint.NET.Rest.Models.Request;
using OctoPrint.NET.Rest.Models.Response;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Clients;

/// <summary>
/// Client responsible for getting and updating the OctoPrint connection information.
/// </summary>
/// 
/// <param name="requester">
/// The <see cref="IApiRequester"/>.
/// </param>
///
/// /// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/connection.html">the OctoPrint Documentation</see> for more details.
/// </remarks>
public class ConnectionClient(IApiRequester requester) : OctoPrintRestClient(requester), IConnectionClient
{
    /// <inheritdoc/>
    public async Task<ConnectionResponse> GetConnection()
    {
        var settings = await Requester.Get<ConnectionResponse>(Endpoints.Connection);

        return settings;
    }

    /// <inheritdoc/>
    public async Task IssueConnectionCommand(ConnectionRequest request) =>
        await Requester.Post(Endpoints.Connection, request, null);
}