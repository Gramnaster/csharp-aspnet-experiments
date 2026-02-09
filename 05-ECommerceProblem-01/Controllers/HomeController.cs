using _05_ECommerceProblem_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace _05_ECommerceProblem_01.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Random _random = new();

        [HttpPost("order")]
        public IActionResult PostOrder([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))]Order order)
        {
            if (!ModelState.IsValid)
            {
                string errorString = string.Join("\n", ModelState.Values.SelectMany((value) => value.Errors).Select((error) => error.ErrorMessage).ToList());

                return BadRequest(errorString);
            }

            int randomOrderNumber = _random.Next(1, 99999);
            return Content($"Order No:{randomOrderNumber}");
        }
    }
}
