namespace OctoPrint.NET.Json.Models.Shared;

/// <summary>
/// The current state of the SD card.  
/// </summary>
public class SdState
{
    /// <summary>
    /// True if the printer’s SD card is available and initialized, false otherwise.
    /// </summary>
    public required bool Ready { get; init; }
}