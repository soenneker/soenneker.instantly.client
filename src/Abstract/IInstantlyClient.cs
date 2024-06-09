using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soenneker.Instantly.Client.Abstract;

/// <summary>
/// A .NET HTTP client for Instantly's API
/// </summary>
public interface IInstantlyClient : IAsyncDisposable, IDisposable
{
    ValueTask<HttpClient> Get();
}