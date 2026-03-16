using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Nws.HttpClients.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface INwsOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Asynchronously retrieves an instance of <see cref="HttpClient"/> for making HTTP requests.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> representing the asynchronous operation. The result contains an <see
    /// cref="HttpClient"/> instance for sending HTTP requests.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}