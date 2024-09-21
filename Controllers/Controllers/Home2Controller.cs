using Controllers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    [Route("register")]
    // [ApiController]
    public class Home2Controller : ControllerBase
    {
        public IActionResult Index([FromBody]Person2 person2)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors)
                .Select(err => err.ErrorMessage));


                List<string> errorList = new();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                }

                errorList.Add(errors);

                return BadRequest(errorList);
            }
            return Content($"{person2}");
        }
    }
}
