using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Monday.GraphQlClient;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Monday.GraphQlClientUtil.Abstract;
using Soenneker.Monday.HttpClients.Abstract;

namespace Soenneker.Monday.GraphQlClientUtil;

///<inheritdoc cref="IMondayGraphQlClientUtil"/>
public sealed class MondayGraphQlClientUtil : IMondayGraphQlClientUtil
{
    private readonly AsyncSingleton<MondayGraphQlClient> _client;

    public MondayGraphQlClientUtil(IMondayGraphQlHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<MondayGraphQlClient>(async (token) =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token);

            return new MondayGraphQlClient(new GraphQlHttpClient(httpClient));
        });
    }

    public ValueTask<MondayGraphQlClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
