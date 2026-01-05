using System;
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
    private const string _clientId = nameof(InstantlyClient);
    private const string _prodBaseUrl = "https://api.instantly.ai/api/v2/";

    private readonly IHttpClientCache _httpClientCache;
    private readonly string _authHeaderValue;

    public InstantlyClient(IHttpClientCache httpClientCache, IConfiguration configuration)
    {
        _httpClientCache = httpClientCache;

        // Fail fast; do not retain IConfiguration.
        var apiKey = configuration.GetValueStrict<string>("Instantly:ApiKey");
        _authHeaderValue = "Bearer " + apiKey;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        // No closure: state passed explicitly + static lambda
        return _httpClientCache.Get(_clientId, _authHeaderValue, static authHeaderValue => new HttpClientOptions
        {
            BaseAddressUri = new Uri(_prodBaseUrl),
            DefaultRequestHeaders = new Dictionary<string, string>(1)
            {
                { "Authorization", authHeaderValue }
            }
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