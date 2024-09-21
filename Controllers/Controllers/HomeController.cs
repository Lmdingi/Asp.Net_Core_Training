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

        [Route("bookstore/{bookId?}/{isLoggedIn}")]
        public IActionResult BookIndex(int? bookId, [FromRoute]bool? isLoggedIn, 
        Book book)
        {

            if (bookId.HasValue == false )
            {
                return BadRequest("Book id is not supplied or maybe empty");
            }

            if (bookId <= 0)
            {
                return BadRequest("Book id can't be less than zero");
            }

            if (bookId > 1000)
            {

                return NotFound("Book id can't be greater than 1000");
            }

            if (isLoggedIn == false)
            {
                return Unauthorized("User must be authenticated");
            }

            // return File("Resume.pdf", "application/pdf");
            // return RedirectToAction("Books", "Store", new { id = bookid });
            // return RedirectToActionPermanent("Books", "Store", new { id = bookid, id2 = bookid2 });
            return Content($"bookId: {bookId} <==> isLoggedIn: {isLoggedIn} <==> book: {book}");
        }

    }
}
