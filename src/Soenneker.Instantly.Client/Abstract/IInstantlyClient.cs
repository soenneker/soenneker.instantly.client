using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Client.Abstract;

/// <summary>
/// A .NET HTTP client for Instantly's API
/// </summary>
public interface IInstantlyClient : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}