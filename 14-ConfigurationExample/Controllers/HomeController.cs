using _14_ConfigurationExample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _14_ConfigurationExample.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly WeatherApiOptions _options;

        // You can inject it here directly
        public HomeController(IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _options = weatherApiOptions.Value;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            //string clientId = _configuration.GetValue<string>("WeatherApi:ClientID", "default-client-id");
            //string clientSecret = _configuration.GetValue<string>("WeatherApi:ClientSecret", "default-client-secret");

            //IConfigurationSection weatherApiSection = _configuration.GetSection("WeatherApi");

            //string clientId = weatherApiSection["ClientId"]!;
            //string clientSecret = weatherApiSection["ClientSecret"]!;

            //WeatherApiOptions weatherApiSection = _configuration.GetSection("WeatherApi").Get<WeatherApiOptions>() ?? new WeatherApiOptions();

            // Loads configs into existing Options object
            //WeatherApiOptions options = new();
            //_configuration.GetSection("WeatherApi").Bind(options);

            //string clientId = weatherApiSection.ClientId ?? "default-client-id";
            //string clientSecret = weatherApiSection.ClientSecret ?? "default-client-secret";

            string clientId = _options.ClientId;
            string clientSecret = _options.ClientSecret;

            return Ok(new {
                clientId,
                clientSecret
            });
        }
    }
}
