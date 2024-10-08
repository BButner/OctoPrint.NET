namespace OctoPrint.NET.Rest;

/// <summary>
/// Class containing all of the OctoPrint endpoints.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Endpoint to interact with the Connection settings, init a connection, etc.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/connection.html">the OctoPrint Docs</see>
    /// for more details.
    /// </remarks>
    public static Uri Connection = new($"{EndpointPrefix}/connection", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the OctoPrint Server information.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/server.html">the OctoPrint Docs</see>
    /// for more details.
    /// </remarks>
    public static Uri Server = new($"{EndpointPrefix}/server", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the OctoPrint Version information.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/version.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static Uri Version = new($"{EndpointPrefix}/version", UriKind.Relative);

    private const string EndpointPrefix = "/api";
}