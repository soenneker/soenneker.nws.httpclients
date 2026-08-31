using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Nws.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client configured for the National Weather Service API.
/// </summary>
public interface INwsOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured National Weather Service HTTP client.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>The cached client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
