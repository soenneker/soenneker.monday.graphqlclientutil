using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Monday.HttpClients.Registrars;
using Soenneker.Monday.GraphQlClientUtil.Abstract;

namespace Soenneker.Monday.GraphQlClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton GraphQL client
/// </summary>
public static class MondayGraphQlClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="MondayGraphQlClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddMondayGraphQlClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddMondayGraphQlHttpClientAsSingleton()
                .TryAddSingleton<IMondayGraphQlClientUtil, MondayGraphQlClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="MondayGraphQlClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddMondayGraphQlClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddMondayGraphQlHttpClientAsSingleton()
                .TryAddScoped<IMondayGraphQlClientUtil, MondayGraphQlClientUtil>();

        return services;
    }
}
