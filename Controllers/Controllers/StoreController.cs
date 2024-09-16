using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class StoreController : Controller
    {
       [Route("store/books/{id?}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            int id2 = Convert.ToInt32(Request.RouteValues["id2"]);
           return Content($"<h1>{id} === REDIRECTED === {id2}</h1>", "text/html");
        }

    }
}
