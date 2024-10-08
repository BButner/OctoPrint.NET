using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OctoPrint.NET.Rest.Requester;

/// <summary>
/// Class responsible for making the REST requests to the OctoPrint backend.
/// </summary>
public class OctoPrintRequester(Uri baseAddress, string apiKey) : IApiRequester
{
    /// <summary>
    /// The default <see cref="JsonSerializerOptions"/> to be used on all requests.
    /// </summary>
    public static JsonSerializerOptions DefaultSerializerOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower)
        },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <inheritdoc/>
    public async Task<T> Get<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<T>(uri, DefaultSerializerOptions, cancellationToken);

        if (response is null)
        {
            throw new HttpRequestException();
        }

        return response;
    }

    /// <inheritdoc/>
    public async Task Post(Uri uri, CancellationToken cancellationToken = default) =>
        await _httpClient.PostAsync(uri, null, cancellationToken);

    /// <inheritdoc/>
    public async Task Post<T>(Uri uri, T requestBody, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        await _httpClient.PostAsJsonAsync(uri, requestBody, options ?? DefaultSerializerOptions, cancellationToken);

    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = baseAddress,
        DefaultRequestHeaders =
        {
            Authorization = new AuthenticationHeaderValue("Bearer", apiKey),
        },
    };
}