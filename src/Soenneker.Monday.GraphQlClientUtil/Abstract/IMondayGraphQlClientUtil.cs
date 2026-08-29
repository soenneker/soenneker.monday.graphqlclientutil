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
    /// <summary>
    /// Returns the configured monday Graph Ql Client used by the Monday Graph Ql Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested monday Graph Ql Client.</returns>
    ValueTask<MondayGraphQlClient> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a cached client for a specific Monday API key using the configured base URL.
    /// </summary>
    /// <param name="apiKey">API key used to authenticate the request.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested monday Graph Ql Client.</returns>
    ValueTask<MondayGraphQlClient> Get(string apiKey, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a cached client for a specific Monday connection.
    /// </summary>
    /// <param name="apiKey">API key used to authenticate the request.</param>
    /// <param name="baseUrl">URL of the base to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested monday Graph Ql Client.</returns>
    ValueTask<MondayGraphQlClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default);
}
