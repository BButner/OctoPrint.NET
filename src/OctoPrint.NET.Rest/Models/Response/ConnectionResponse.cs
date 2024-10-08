using System.Text.Json.Serialization;

namespace OctoPrint.NET.Rest.Models.Response;

/// <summary>
/// Response from the backend with the connection information.
/// </summary>
///
/// <remarks>
/// See <see href="https://docs.octoprint.org/en/master/api/connection.html#get--api-connection">the OctoPrint Docs</see> for more details.
/// </remarks>
public class ConnectionResponse
{
    /// <summary>
    /// The current connection information.
    /// </summary>
    public required CurrentConnectionResponse Current { get; set; }

    /// <summary>
    /// The current available options.
    /// </summary>
    public required CurrentOptionsResponse Options { get; set; }
}

/// <summary>
/// The current connection response.
/// </summary>
public class CurrentConnectionResponse
{
    /// <summary>
    /// The current printer state.
    /// </summary>
    public required string State { get; set; }

    /// <summary>
    /// The current connected port.
    /// </summary>
    public string? Port { get; set; }

    /// <summary>
    /// The current baud rate.
    /// </summary>
    [JsonPropertyName("baudrate")]
    public int? BaudRate { get; set; }

    /// <summary>
    /// The current printer profile.
    /// </summary>
    public required string PrinterProfile { get; set; }
}

/// <summary>
/// The current connection options response.
/// </summary>
public class CurrentOptionsResponse
{
    /// <summary>
    /// The available ports.
    /// </summary>
    public required string[] Ports { get; set; }

    /// <summary>
    /// The available baud rates.
    /// </summary>
    [JsonPropertyName("baudrates")]
    public required int[] BaudRates { get; set; }

    /// <summary>
    /// The available collection of <see cref="PrinterProfileResponse"/>.
    /// </summary>
    public required PrinterProfileResponse[] PrinterProfiles { get; set; }

    /// <summary>
    /// The preferred port.
    /// </summary>
    public string? PortPreference { get; set; }

    /// <summary>
    /// The preferred baud rate.
    /// </summary>
    [JsonPropertyName("baudratePreference")]
    public int? BaudRatePreference { get; set; }

    /// <summary>
    /// The id of the preferred printer profile.
    /// </summary>
    public required string PrinterProfilePreference { get; set; }

    /// <summary>
    /// Whether or not the printer should auto connect.
    /// </summary>
    public bool? AutoConnect { get; set; }
}

/// <summary>
/// Printer profile response in the <see cref="CurrentOptionsResponse"/>.
/// </summary>
public class PrinterProfileResponse
{
    /// <summary>
    /// The name of the profile.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The id of the profile.
    /// </summary>
    public required string Id { get; set; }
}