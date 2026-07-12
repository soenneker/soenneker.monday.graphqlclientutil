using Soenneker.Monday.GraphQlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Monday.GraphQlClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton GraphQL client
/// </summary>
public interface IMondayGraphQlClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<MondayGraphQlClient> Get(CancellationToken cancellationToken = default);

    /// <summary>Gets a cached client for a specific Monday API key using the configured base URL.</summary>
    ValueTask<MondayGraphQlClient> Get(string apiKey, CancellationToken cancellationToken = default);

    /// <summary>Gets a cached client for a specific Monday connection.</summary>
    ValueTask<MondayGraphQlClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default);
}
