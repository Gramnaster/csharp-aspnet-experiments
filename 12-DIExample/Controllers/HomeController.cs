using _12_DIExample_ServiceContracts;
using _12_DIExample_Services;
using Microsoft.AspNetCore.Mvc;

namespace _12_DIExample.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory; // Inject this interface

        // Constructor injection
        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceScopeFactory serviceScopeFactory)
        {
            //You don't directly create an object here
            // Use the interface above instead
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        // We use method injection instead so it's more direct
        //public IActionResult Index([FromServices] ICitiesService _citiesService)
        public IActionResult Index()
        {
            List<string> cities = _citiesService1.GetCities();
            Guid scopedInstanceId; // Captures the scoped instance ID

            // Create new scope
            // Generally unnecessary unless you're writing your own DB read/write stuff
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                // Inject CitiesService and creates a new
                // Same as injecting ICitiesService into instructor, which returns a new object
                ICitiesService citiesService4 = scope.ServiceProvider.GetRequiredService<ICitiesService>();
                // DB Work
                scopedInstanceId = citiesService4.ServiceInstanceId; // Includes it in anonymous object I return

                // You want to close the Scope as fast as possible

            }   // End of this scope as part of this scope and automatically calls Dispose()

            // To create a Child Scope, you must inject a new Scope
            return Ok(new
            { 
                cities,
                instanceId1 = _citiesService1.ServiceInstanceId,
                instanceId2 = _citiesService2.ServiceInstanceId,
                instanceId3 = _citiesService3.ServiceInstanceId,
                instanceId4 = scopedInstanceId,
            });
        }
    }
}
