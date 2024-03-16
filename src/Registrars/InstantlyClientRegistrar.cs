using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Instantly.Client.Registrars;

/// <summary>
/// A .NET HTTP client for Instantly's API
/// </summary>
public static class InstantlyClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IInstantlyClient"/> as a singleton service. <para/>
    /// </summary>
    public static void AddInstantlyClientAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IInstantlyClient, InstantlyClient>();
        services.AddHttpClientCache();
    }

    /// <summary>
    /// Adds <see cref="IInstantlyClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddInstantlyClientAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IInstantlyClient, InstantlyClient>();
        services.AddHttpClientCache();
    }
}
