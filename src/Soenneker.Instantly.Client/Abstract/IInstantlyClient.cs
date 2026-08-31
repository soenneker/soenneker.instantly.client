using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Client.Abstract;

/// <summary>
/// Provides a cached HTTP client authenticated for Instantly's v2 API.
/// </summary>
public interface IInstantlyClient : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Gets the authenticated Instantly HTTP client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the configured client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
