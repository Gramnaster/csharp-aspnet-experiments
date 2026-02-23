using _12_DIExample_Services;
using Microsoft.AspNetCore.Mvc;

namespace _12_DIExample.Controllers
{
    [ApiController]
public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        public HomeController()
        {
            _citiesService = new CitiesService();
        }

        [Route("/")]    
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return Ok(cities);
        }
    }
}
