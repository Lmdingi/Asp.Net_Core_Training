using System;

namespace StocksApp.Services;

public interface IFinnhubService
{
 Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
}
