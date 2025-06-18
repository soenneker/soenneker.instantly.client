using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Extensions.Configuration;

namespace Soenneker.Instantly.Client;

/// <inheritdoc cref="IInstantlyClient"/>
public sealed class InstantlyClient : IInstantlyClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _configuration;

    private const string _clientId = nameof(InstantlyClient);

    private const string _prodBaseUrl = "https://api.instantly.ai/api/v2/";

    public InstantlyClient(IHttpClientCache httpClientCache, IConfiguration configuration)
    {
        _httpClientCache = httpClientCache;
        _configuration = configuration;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_clientId, () =>
        {
            var apiKey = _configuration.GetValueStrict<string>("Instantly:ApiKey");

            var options = new HttpClientOptions
            {
                BaseAddress = _prodBaseUrl,
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    {"Authorization", $"Bearer {apiKey}"}
                }
            };

            return options;
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