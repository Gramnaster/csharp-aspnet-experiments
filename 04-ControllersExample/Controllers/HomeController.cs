using _04_ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04_ControllersExample.Controllers
{
    //[Controller] 
    // Attribute not required because we have the suffix + Controller inheritance
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")] //localhost port number
        public IActionResult Index()
        {
            //return Content("Hello from Index", "text/plain");
            //return new ContentResult() 
            //{ 
            //    Content = "Hello from Index",
            //    ContentType = "text/plain",
            //    StatusCode = 200
            //};
            return Content("<h2>Howdy</h2> <h3>Love you</h3>", "text/html");
        }

        [Route("person")]
        public IActionResult Person()
        {
            Person person = new() { 
                Id = Guid.NewGuid(),
                FirstName = "Jacob",
                LastName = "Sam",
                Age = 25
            };
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("contact/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }

        [Route("download1")]
        public IActionResult Download() // File relative path, especially wwwroot
        {
            return File("/sample.txt", "text/plain");
        }

        [Route("download2")]
        public IActionResult PhysicalDownload() // File absolute path, especially wwwroot
        {
            return PhysicalFile("C:\\Users\\jocvi\\Documents\\Collection-of-Folders\\Programming\\CSharp\\01-MyFirstApp\\04-ControllersExample\\wwwroot\\sample.txt", "text/plain");
        }

        [Route("download3")]
        public IActionResult FileContentDownload() // File byte array, especially wwwroot
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\jocvi\Documents\Collection-of-Folders\Programming\CSharp\01-MyFirstApp\04-ControllersExample\wwwroot\sample.txt");
            return File(bytes, "text/plain");
        }
    }
}
