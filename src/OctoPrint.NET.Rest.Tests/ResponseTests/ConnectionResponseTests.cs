using System.Text.Json;
using OctoPrint.NET.Rest.Models.Response;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Tests.ResponseTests;

public class ConnectionResponseTests
{
    [Fact]
    public void TestExampleResponse()
    {
        var contents = """
                       {
                         "current": {
                           "state": "Operational",
                           "port": "/dev/ttyACM0",
                           "baudrate": 250000,
                           "printerProfile": "_default"
                         },
                         "options": {
                           "ports": ["/dev/ttyACM0", "VIRTUAL"],
                           "baudrates": [250000, 230400, 115200, 57600, 38400, 19200, 9600],
                           "printerProfiles": [{"name": "Default", "id": "_default"}],
                           "portPreference": "/dev/ttyACM0",
                           "baudratePreference": 250000,
                           "printerProfilePreference": "_default",
                           "autoconnect": true
                         }
                       }
                       """;
        var response =
            JsonSerializer.Deserialize<ConnectionResponse>(contents, OctoPrintRequester.DefaultSerializerOptions);

        Assert.NotNull(response);
    }

    [Fact]
    public void TestWithoutPreferences()
    {
        var contents = """
                       {
                         "current": {
                           "baudrate": 115200,
                           "port": "/dev/ttyACM0",
                           "printerProfile": "_default",
                           "state": "Printing"
                         },
                         "options": {
                           "baudratePreference": null,
                           "baudrates": [
                             250000,
                             230400,
                             115200,
                             57600,
                             38400,
                             19200,
                             9600
                           ],
                           "portPreference": null,
                           "ports": [
                             "/dev/ttyACM0"
                           ],
                           "printerProfilePreference": "_default",
                           "printerProfiles": [
                             {
                               "id": "_default",
                               "name": "SomePrinterName"
                             }
                           ]
                         }
                       }
                       """;
        var response =
            JsonSerializer.Deserialize<ConnectionResponse>(contents, OctoPrintRequester.DefaultSerializerOptions);

        Assert.NotNull(response);
    }
}