using System.Text.Json;
using OctoPrint.NET.Rest.Models.Response;
using OctoPrint.NET.Rest.Requester;

namespace OctoPrint.NET.Rest.Tests.ResponseTests;

public class VersionResponseTests
{
    [Fact]
    public void TestExampleResponse()
    {
        var contents = """
                       {
                         "api": "0.1",
                         "server": "1.3.10",
                         "text": "OctoPrint 1.3.10"
                       }
                       """;
        var versionInfo =
            JsonSerializer.Deserialize<VersionResponse>(contents, OctoPrintRequester.DefaultSerializerOptions);

        Assert.NotNull(versionInfo);
    }
}