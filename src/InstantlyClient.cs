using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Instantly.Client;

/// <inheritdoc cref="IInstantlyClient"/>
public sealed class InstantlyClient : IInstantlyClient
{
    private readonly IHttpClientCache _httpClientCache;

    private const string _clientId = nameof(InstantlyClient);

    public InstantlyClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_clientId, () => new HttpClientOptions
        {
            BaseAddress = "https://api.instantly.ai/api/v1/"
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(_clientId);
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_clientId);
    }
}