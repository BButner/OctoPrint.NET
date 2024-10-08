using System.Text.Json;
using System.Text.Json.Nodes;
using OctoPrint.NET.Rest.Models.Request;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Tests.RequestTests;

public class ConnectionRequestTests
{
    [Fact]
    public void TestExampleConnectRequest()
    {
        string serialized =
            """{"command":"connect","port":"/dev/ttyACM0","baudrate":115200,"printerProfile":"my_printer_profile","save":true,"autoconnect":true}""";

        var connectRequest = new ConnectionRequest
        {
            Command = ConnectionCommand.Connect,
            Port = "/dev/ttyACM0",
            BaudRate = 115200,
            PrinterProfile = "my_printer_profile",
            Save = true,
            AutoConnect = true
        };

        var serializedJson = JsonSerializer.Serialize(connectRequest, OctoPrintRequester.DefaultSerializerOptions);

        Assert.Equal(serialized, serializedJson);
    }

    [Fact]
    public void TestExampleDisconnectRequest()
    {
        string serialized =
            """{"command":"disconnect"}""";

        var disconnectRequest = new ConnectionRequest
        {
            Command = ConnectionCommand.Disconnect
        };

        var serializedJson = JsonSerializer.Serialize(disconnectRequest, OctoPrintRequester.DefaultSerializerOptions);

        Assert.Equal(serialized, serializedJson);
    }

    [Fact]
    public void TestExampleFakeAckRequest()
    {
        string serialized =
            """{"command":"fake_ack"}""";

        var fakeAckRequest = new ConnectionRequest
        {
            Command = ConnectionCommand.FakeAck
        };

        var serializedJson = JsonSerializer.Serialize(fakeAckRequest, OctoPrintRequester.DefaultSerializerOptions);

        Assert.Equal(serialized, serializedJson);
    }
}