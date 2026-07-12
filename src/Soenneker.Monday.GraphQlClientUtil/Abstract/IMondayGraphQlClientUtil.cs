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
}
