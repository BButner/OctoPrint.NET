using OctoPrint.NET.Rest.Clients.Interfaces;
using OctoPrint.NET.Rest.Models.Response;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Clients;

/// <summary>
/// Client responsible for making requests related to the OctoPrint version.
/// </summary>
/// 
/// <param name="requester">
/// The <see cref="IApiRequester"/> handler.
/// </param>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/version.html">OctoPrint Documentation</see> for more details.
/// </remarks>
public class VersionClient(IApiRequester requester) : OctoPrintRestClient(requester), IVersionClient
{
    /// <inheritdoc/>
    public async Task<VersionResponse> GetVersion()
    {
        var version = await Requester.Get<VersionResponse>(Endpoints.Version);

        return version;
    }
}