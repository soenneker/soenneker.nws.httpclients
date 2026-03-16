using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Nws.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Nws.HttpClients;

///<inheritdoc cref="IOpenApiHttpClient"/>
public sealed class OpenApiHttpClient : IOpenApiHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrl = "https://api.weather.gov";

    public OpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(OpenApiHttpClient), (config: _config, prodBaseUrl: _prodBaseUrl), static state =>
        {
            var userAgent = state.config.GetValueStrict<string>("Nws:UserAgent");

            return new HttpClientOptions
            {
                BaseAddress = new Uri(state.prodBaseUrl),
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    { "User-Agent", userAgent }
                }
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(OpenApiHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(OpenApiHttpClient));
    }
}