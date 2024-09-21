using System;
using System.Text.Json;

namespace StocksApp.Services;

public class FinnhubService : IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        
    }

    public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage httpRequestMessage = new()
            {
                RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=crnfq49r01qt44dhfj70crnfq49r01qt44dhfj7g"),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            Stream stream = httpResponseMessage.Content.ReadAsStream();

            StreamReader streamReader = new(stream);

            string response = streamReader.ReadToEnd();

            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No data from finnhub");
            }

            if (responseDictionary.ContainsKey("error"))
            {
                throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));
            }
            return responseDictionary;
        }
    }
}
