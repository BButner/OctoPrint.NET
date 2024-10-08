namespace OctoPrint.NET.Rest.Clients.Interfaces;

/// <summary>
/// Defines the functionality for an implementing OctoPrint client.
/// </summary>
public interface IOctoPrintClient
{
    /// <summary>
    /// The Hostname/URL of the OctoPrint instance.
    /// </summary>
    string Hostname { get; init; }

    /// <summary>
    /// The ApiKey of the OctoPrint instance.
    /// </summary>
    ///
    /// <remarks>
    /// See <see href="https://docs.octoprint.org/en/master/api/general.html#authorization">the OctoPrint Docs</see>
    /// for information on how to get your ApiKey.
    /// </remarks>
    string ApiKey { get; init; }

    /// <summary>
    /// The port of the OctoPrint instance.
    /// </summary>
    ///
    /// <value>
    /// Default: 80
    /// </value>
    int Port { get; init; }

    /// <summary>
    /// Gets the <see cref="IConnectionClient"/>.
    /// </summary>
    IConnectionClient Connection { get; init; }

    /// <summary>
    /// Gets the <see cref="IServerClient"/>.
    /// </summary>
    IServerClient Server { get; init; }

    /// <summary>
    /// Gets the <see cref="IVersionClient"/>.
    /// </summary>
    IVersionClient Version { get; init; }
}