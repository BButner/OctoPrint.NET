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
    public static readonly Uri Connection = new($"{EndpointPrefix}/connection", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the OctoPrint Server information.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/server.html">the OctoPrint Docs</see>
    /// for more details.
    /// </remarks>
    public static readonly Uri Server = new($"{EndpointPrefix}/server", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the OctoPrint Version information.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/version.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri Version = new($"{EndpointPrefix}/version", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the current printer state.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterState = new($"{EndpointPrefix}/printer", UriKind.Relative);

    /// <summary>
    /// Endpoint to issue a print head command.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterPrintHead = new($"{EndpointPrefix}/printer/printhead", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the state of a tool, or issue a command.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterTool = new($"{EndpointPrefix}/printer/tool", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the current state of the bed, or issue a command.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterBed = new($"{EndpointPrefix}/printer/bed", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the current state of the chamber, or issue a command.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterChamber = new($"{EndpointPrefix}/printer/chamber", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the current state of the SD card, or issue a command.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterSd = new($"{EndpointPrefix}/printer/sd", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the information about the last error.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterError = new($"{EndpointPrefix}/printer/error", UriKind.Relative);

    /// <summary>
    /// Endpoint to send an arbitrary command to the printer.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterCommand = new($"{EndpointPrefix}/printer/command", UriKind.Relative);

    /// <summary>
    /// Endpoint to get the custom controls.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/printer.html">the OctoPrint Docs</see> for more details.
    /// </remarks>
    public static readonly Uri PrinterCustomControls =
        new($"{EndpointPrefix}/printer/command/custom", UriKind.Relative);

    private const string EndpointPrefix = "/api";
}