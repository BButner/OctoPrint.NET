using OctoPrint.NET.Rest.Clients.Interfaces;
using OctoPrint.NET.Rest.Models.Response;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Clients;

/// <summary>
/// Client responsible for making requests related to the OctoPrint server information.
/// </summary>
/// 
/// <param name="requester">
/// The <see cref="IApiRequester"/>.
/// </param>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/server.html">the OctoPrint Docs</see> for more details.
/// </remarks>
public class ServerClient(IApiRequester requester) : OctoPrintRestClient(requester), IServerClient
{
    /// <inheritdoc/>
    public async Task<ServerResponse> GetServerInformation()
    {
        var serverInformation = await Requester.Get<ServerResponse>(Endpoints.Server);

        return serverInformation;
    }
}