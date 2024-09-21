using Microsoft.AspNetCore.Mvc;

namespace EnvernmentExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public ActionResult Index()
        {
            ViewBag.CurrentEnveromnent = _webHostEnvironment.EnvironmentName;
            return View();
        }

    }
}
