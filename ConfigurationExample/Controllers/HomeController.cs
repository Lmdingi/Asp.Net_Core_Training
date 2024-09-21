using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration1;
        private readonly WeatherOptions _configuration2;
        public HomeController(IConfiguration configuration1, IOptions<WeatherOptions> configuration2)
        {
            _configuration1 = configuration1;
            _configuration2 = configuration2.Value;
        }

        [Route("/")]
        public ActionResult Index()
        {
            ViewBag.MyKey1 = _configuration1["MyKey"];
            ViewBag.MyKey2 = _configuration1.GetValue<string>("AllowedHosts");
            ViewBag.MyKey3 = _configuration1.GetValue<string>("x", "add default if 'x' is not found");
            /*********************************/
            ViewBag.NestedKey1 = _configuration1["WeatherApi:ClientID"];
            ViewBag.NestedKey2 = _configuration1.GetValue<string>("WeatherApi:ClientSecrete");
            ViewBag.NestedKey3 = _configuration1.GetValue<string>("x", "add default if nested 'x' is not found");
            /*********************************/
            IConfiguration section = _configuration1.GetSection("Section");
            ViewBag.Section1 = section["ClientID"];
            ViewBag.Section2 = section["ClientSecrete"];
            /**/
            WeatherOptions options = section.Get<WeatherOptions>();
            ViewBag.bind1 = options.ClientID;
            ViewBag.bind2 = options.ClientSecrete;
            /*********************************/
            ViewBag.Options1 = _configuration2.ClientID;
            ViewBag.Options2 = _configuration2.ClientSecrete;
            return View();
        }

    }
}
