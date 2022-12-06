using System.Net.Http.Json;
using BeelineTest.Data.Entity;
using BeelineTest.Data.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BeelineTest.Data;

public class DataService
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    private readonly IConfiguration _configuration = null!;
    private readonly ILogger<DataService> _logger = null!;

    public DataService(IHttpClientFactory httpClientFactory, IConfiguration configuration,
        ILogger<DataService> logger) =>
        (_httpClientFactory, _configuration, _logger) = (httpClientFactory, configuration, logger);

    private async Task<Daily?> GetDailyAsync(CancellationToken cancellationToken)
    {
        var httpClientName = _configuration["CbrXmlDailyRu"];
        using var client = _httpClientFactory.CreateClient(httpClientName ?? "");

        try
        {
            var daily = await client.GetFromJsonAsync<Daily>("daily_json.js", DefaultJsonSerialization.Options,
                cancellationToken);

            return daily;
        }
        catch (Exception e)
        {
            _logger.LogError("Error: {Error}", e);
        }

        return default;
    }

    public async Task<string[]> GetNameValutesAsync(CancellationToken cancellationToken)
    {
        var daily = await GetDailyAsync(cancellationToken);
        var nameCurrencies = daily?.Valute.Keys.ToArray();

        return nameCurrencies ?? Array.Empty<string>();
    }

    public async Task<decimal> GetValuteValue(string charCode, CancellationToken cancellationToken)
    {
        var daily = await GetDailyAsync(cancellationToken);
        var currency = daily?.Valute[charCode].Value;

        return currency ?? default;
    }
}