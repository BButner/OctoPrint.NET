using System.Text.Json;
using OctoPrint.NET.Json;
using OctoPrint.NET.Rest.Models.Response;

namespace OctoPrint.NET.Rest.Tests.ResponseTests;

public class ServerResponseTests
{
    [Fact]
    public void TestExampleResponse()
    {
        var contents = """{"version": "1.5.0","safemode": "incomplete_startup"}""";
        var result = JsonSerializer.Deserialize<ServerResponse>(contents, OctoPrintJson.DefaultSerializerOptions);

        Assert.NotNull(result?.SafeMode);
    }

    [Fact]
    public void TestFalseResponse()
    {
        var contents = """{"version": "1.5.0","safemode": false}""";
        var result = JsonSerializer.Deserialize<ServerResponse>(contents, OctoPrintJson.DefaultSerializerOptions);

        Assert.NotNull(result?.SafeMode);
    }
}