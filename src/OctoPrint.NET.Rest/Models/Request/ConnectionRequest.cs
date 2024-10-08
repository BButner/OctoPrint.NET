using System.Text.Json.Serialization;

namespace OctoPrint.NET.Rest.Models.Request;

/// <summary>
/// Request used to issue a connection command.
/// </summary>
public class ConnectionRequest
{
    /// <summary>
    /// The <see cref="ConnectionCommand"/> to be sent.
    /// </summary>
    public required ConnectionCommand Command { get; set; }

    /// <summary>
    /// The specific port to connect to.
    ///
    /// If not set, the current portPreference will be used, or if no preference
    /// is available auto detection will be attempted.
    /// </summary>
    public string? Port { get; set; }

    /// <summary>
    /// The baudrate to connect with.
    ///
    /// If not set, the current baudratePreference will be used, or if no preference
    /// available auto detection will be attempted.
    /// </summary>
    [JsonPropertyName("baudrate")]
    public int? BaudRate { get; set; }

    /// <summary>
    /// Which printer profile to use.
    ///
    /// If nto set the current default printer profile will be used.
    /// </summary>
    public string? PrinterProfile { get; set; }

    /// <summary>
    /// Whether to save the requests Port and Baudrate settings as new preferences. Defaults
    /// to false if not set.
    /// </summary>
    public bool? Save { get; set; }

    /// <summary>
    /// Whether to automatically connect to the printer on OctoPrint's startup in the
    /// future. If not set no changes will be made to the current configuration.
    /// </summary>
    [JsonPropertyName("autoconnect")]
    public bool? AutoConnect { get; set; }
}

/// <summary>
/// Available commands for a <see cref="ConnectionRequest"/>.
/// </summary>
public enum ConnectionCommand
{
    Connect,
    Disconnect,
    FakeAck
}