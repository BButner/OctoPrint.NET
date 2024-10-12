using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using OctoPrint.NET.Json;

namespace OctoPrint.NET.Rest.Requester;

/// <summary>
/// Class responsible for making the REST requests to the OctoPrint backend.
/// </summary>
public class OctoPrintRequester(Uri baseAddress, string apiKey) : IApiRequester
{
    /// <inheritdoc/>
    public async Task<T> Get<T>(Uri uri, CancellationToken cancellationToken = default)
    {
        var response =
            await _httpClient.GetFromJsonAsync<T>(uri, OctoPrintJson.DefaultSerializerOptions, cancellationToken);

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
        await _httpClient.PostAsJsonAsync(uri, requestBody, options ?? OctoPrintJson.DefaultSerializerOptions,
            cancellationToken);

    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = baseAddress,
        DefaultRequestHeaders =
        {
            Authorization = new AuthenticationHeaderValue("Bearer", apiKey),
        },
    };
}