using Microsoft.AspNetCore.Mvc;

namespace _13_EnvironmentsExample.Controllers
{
    [ApiController]
    //[Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            string currentEnvironment = _webHostEnvironment.EnvironmentName;
            return Ok(new { 
                environment = currentEnvironment,
                message = "Hello",
            });
        }

        [HttpGet("health")]
        public IActionResult Health() => Ok();
    }
}
