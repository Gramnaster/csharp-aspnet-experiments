using _05_ModelBindingExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace _05_ModelBindingExample.Controllers;

public class HomeController : Controller
{
    [Route("register")]
    // Binding the properties of the model like this if you have fewer properties to bind
    // [Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
    public IActionResult Index(Person person)
    {
        
        if (!ModelState.IsValid)
        {
            // LINQ to shorten the errors
            string errorsString = string.Join("\n", 
                            ModelState.Values
                            .SelectMany((value) => value.Errors)
                            .Select((error) => error.ErrorMessage)
                            .ToList());

            return BadRequest(errorsString);
        }
        return Content($"{person}");
    }
}
