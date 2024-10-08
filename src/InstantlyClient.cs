using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;
using Soenneker.Utils.HttpClientCache.Dtos;

namespace Soenneker.Instantly.Client;

///<inheritdoc cref="IInstantlyClient"/>
public class InstantlyClient : IInstantlyClient
{
    private readonly IHttpClientCache _httpClientCache;

    private readonly HttpClientOptions _options = new() { BaseAddress = "https://api.instantly.ai/api/v1/" };

    public InstantlyClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(InstantlyClient), _options, cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.RemoveSync(nameof(InstantlyClient));
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _httpClientCache.Remove(nameof(InstantlyClient));
    }
}