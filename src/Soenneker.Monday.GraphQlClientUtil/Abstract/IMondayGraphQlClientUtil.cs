using Soenneker.Monday.GraphQlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Monday.GraphQlClientUtil.Abstract;

/// <summary>
/// Provides cached, authenticated Monday GraphQL clients for one or more connections.
/// </summary>
public interface IMondayGraphQlClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets a client using the configured API key and base URL.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The configured Monday GraphQL client.</returns>
    ValueTask<MondayGraphQlClient> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a cached client for a specific Monday API key using the configured base URL.
    /// </summary>
    /// <param name="apiKey">API key used to authenticate the request.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The configured Monday GraphQL client.</returns>
    ValueTask<MondayGraphQlClient> Get(string apiKey, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a cached client for a specific Monday connection.
    /// </summary>
    /// <param name="apiKey">API key used to authenticate the request.</param>
    /// <param name="baseUrl">Absolute Monday GraphQL endpoint to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The configured Monday GraphQL client.</returns>
    ValueTask<MondayGraphQlClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default);
}
