using Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Hello from Index</h1>", "text/html");
        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact(string mobile)
        {
            return "Hello from Contact";
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new()
            {
                Id = Guid.NewGuid(),
                Age = 32,
                FirsName = "Luxolo",
                LastName = "Mdingi"
            };

            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return File("Resume.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return PhysicalFile(@"C:\Users\Dan Tec Gaming\Documents\Asp.Net_Core_Training\Controllers\wwwroot\Resume.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Dan Tec Gaming\Documents\Asp.Net_Core_Training\Controllers\wwwroot\Resume.pdf");

            return File(bytes, "application/pdf");
        }

        [Route("bookstore")]
        public IActionResult BookIndex()
        {

            if (!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("Book id is not supplied");
            }

            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {

                return BadRequest("Book id can't be null or empty");
            }

            int bookid = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            int bookid2 = Convert.ToInt16(Request.Query["bookid"]);

            if (bookid <= 0)
            {

                return BadRequest("Book id can't be less than zero");
            }

            if (bookid > 1000)
            {

                return NotFound("Book id can't be greater than 1000");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {

                return Unauthorized("User must be authenticated");
            }

            // return File("Resume.pdf", "application/pdf");
            // return RedirectToAction("Books", "Store", new { id = bookid });
            return RedirectToActionPermanent("Books", "Store", new { id = bookid, id2 = bookid2 });
        }

    }
}
