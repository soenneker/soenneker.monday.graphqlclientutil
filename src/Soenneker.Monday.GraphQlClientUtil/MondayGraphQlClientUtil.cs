using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dictionaries.Singletons;
using Soenneker.Extensions.Configuration;
using Soenneker.Monday.GraphQlClient;
using Soenneker.Monday.GraphQlClientUtil.Abstract;
using Soenneker.Monday.HttpClients.Abstract;

namespace Soenneker.Monday.GraphQlClientUtil;

///<inheritdoc cref="IMondayGraphQlClientUtil"/>
public sealed class MondayGraphQlClientUtil : IMondayGraphQlClientUtil
{
    private readonly SingletonDictionary<MondayGraphQlClient> _clients;
    private readonly IMondayGraphQlHttpClient _httpClientUtil;
    private readonly IConfiguration _configuration;
    private readonly string _baseUrl;

    public MondayGraphQlClientUtil(IMondayGraphQlHttpClient httpClientUtil, IConfiguration configuration)
    {
        _httpClientUtil = httpClientUtil;
        _configuration = configuration;
        _baseUrl = configuration["Monday:ClientBaseUrl"] ?? "https://api.monday.com/v2";
        _clients = new SingletonDictionary<MondayGraphQlClient>(CreateClient);
    }

    private async ValueTask<MondayGraphQlClient> CreateClient(string connectionKey, CancellationToken cancellationToken)
    {
        (string apiKey, string baseUrl) = ParseConnectionKey(connectionKey);
        HttpClient httpClient = await _httpClientUtil.Get(apiKey, baseUrl, cancellationToken);

        return new MondayGraphQlClient(new GraphQlHttpClient(httpClient));
    }

    public ValueTask<MondayGraphQlClient> Get(CancellationToken cancellationToken = default)
    {
        return Get(_configuration.GetValueStrict<string>("Monday:ApiKey"), _baseUrl, cancellationToken);
    }

    public ValueTask<MondayGraphQlClient> Get(string apiKey, CancellationToken cancellationToken = default)
    {
        return Get(apiKey, _baseUrl, cancellationToken);
    }

    public ValueTask<MondayGraphQlClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey);
        ArgumentException.ThrowIfNullOrWhiteSpace(baseUrl);

        string normalizedBaseUrl = new Uri(baseUrl, UriKind.Absolute).AbsoluteUri.TrimEnd('/');

        return _clients.Get(CreateConnectionKey(apiKey, normalizedBaseUrl), cancellationToken);
    }

    private static string CreateConnectionKey(string apiKey, string baseUrl) => string.Concat(apiKey, "\0", baseUrl);

    private static (string ApiKey, string BaseUrl) ParseConnectionKey(string connectionKey)
    {
        int separatorIndex = connectionKey.IndexOf('\0');

        return (connectionKey[..separatorIndex], connectionKey[(separatorIndex + 1)..]);
    }

    public void Dispose()
    {
        _clients.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _clients.DisposeAsync();
    }
}
