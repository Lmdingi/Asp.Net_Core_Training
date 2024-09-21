using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _finnhubService;
        private readonly IOptions<TradingOptions> _tradingOptions;
        public HomeController(FinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            // if (_tradingOptions.Value.DefaultStockSymbol == null)
            // {
            //     _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            // }

            var responseDictionary = await _finnhubService
            .GetStockPriceQuote("MSFT");

            Stock stock = new()
            {
                StockSymbol = "MSFT",
                CurrentPrice = Convert.ToDouble(responseDictionary["c"].ToString(), CultureInfo.InvariantCulture),
                LowestPrice = Convert.ToDouble(responseDictionary["h"].ToString(), CultureInfo.InvariantCulture),
                HighestPrice = Convert.ToDouble(responseDictionary["l"].ToString(), CultureInfo.InvariantCulture),
                OpenPrice = Convert.ToDouble(responseDictionary["o"].ToString(), CultureInfo.InvariantCulture)
            };

            return View(stock);
        }

    }
}
