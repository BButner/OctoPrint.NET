using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Clients;

/// <summary>
/// The client responsible for making the REST requests to the OctoPrint server.
/// </summary>
public abstract class OctoPrintRestClient(IApiRequester requester)
{
    protected IApiRequester Requester { get; } = requester;
}