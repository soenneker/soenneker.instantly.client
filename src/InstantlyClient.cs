using System;
using System.Net.Http;
using System.Threading.Tasks;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Instantly.Client;

///<inheritdoc cref="IInstantlyClient"/>
public class InstantlyClient : IInstantlyClient
{
    private readonly IHttpClientCache _httpClientCache;

    public InstantlyClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get()
    {
        return _httpClientCache.Get(nameof(InstantlyClient));
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