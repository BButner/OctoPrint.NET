using System.Text.Json;

namespace OctoPrint.NET.Rest.Requester;

/// <summary>
/// Describes a class/service that will be used to make the API requests to the backend.
/// </summary>
public interface IApiRequester
{
    /// <summary>
    /// Submits a GET request.
    /// </summary>
    /// 
    /// <param name="uri">
    /// The <see cref="Uri"/> to make the request against.
    /// </param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> to cancel the request.
    /// </param>
    /// 
    /// <typeparam name="T">
    /// The specified type to be returned by the request.
    /// </typeparam>
    /// 
    /// <returns>
    /// An instance of <see cref="T"/>.
    /// </returns>
    Task<T> Get<T>(Uri uri, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits a POST request.
    /// </summary>
    /// 
    /// <param name="uri">
    /// The <see cref="Uri"/> to make the request against.
    /// </param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> to cancel the request.
    /// </param>
    Task Post(Uri uri, CancellationToken cancellationToken = default);

    /// <summary>
    /// Submits a POST request with a JSON body.
    /// </summary>
    /// 
    /// <param name="uri">
    /// The <see cref="Uri"/> to make the request against.
    /// </param>
    /// <param name="requestBody">
    /// The object to be serialized and sent as the request body.
    /// </param>
    /// <param name="options">
    /// The optional <see cref="JsonSerializerOptions"/>.
    /// </param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> to cancel the request.
    /// </param>
    /// 
    /// <typeparam name="T">
    /// The type of the object to be serialized as JSON.
    /// </typeparam>
    Task Post<T>(Uri uri, T requestBody, JsonSerializerOptions? options, CancellationToken cancellationToken = default);
}