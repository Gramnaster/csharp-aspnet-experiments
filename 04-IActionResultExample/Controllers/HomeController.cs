using _04_IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04_IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookId:int}/{isLoggedIn:bool}")]
        public IActionResult Index([FromRoute]int? bookId, [FromRoute]bool? isLoggedIn, 
            Book book)
        {
            //Book book = new Book(); 
            // Book id should be applied
            if (!bookId.HasValue)
            {
                return BadRequest("Book id is not supplied");
            }

            //if (string.IsNullOrWhiteSpace(Convert.ToString(Request.Query["bookid"])))
            //{
            //    return BadRequest("Book id cannot be null or empty");
            //}

            // Book id should be between 1 to 1000
            //int bookId = Convert.ToInt32(Request.Query["bookid"]);
            if (bookId <= 0)
            {
                return BadRequest("Book id can't be less than 0");
            }

            if (bookId > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            // isLoggedIn = true
            if (isLoggedIn == false)
            {
                return Unauthorized("User must be authenticated");
            }

            // 302 - Found - RedirectToActionresult
            //return File("/sample.txt", "text/plain");
            //return new RedirectToActionResult("Books", "Store", new { }); // 302 - Found
            //return RedirectToAction("Books", "Stores", new { id = bookId });

            // 301 - Moved Permanently - RedirectToActionresult
            //return new RedirectToActionResult("Books", "Store", new { }, true); // 301 - Moved Permanently
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            // 302 - Found - LocalRedirectResult
            //return new LocalRedirectResult("store/books/{bookId}"); // Redirect to Action is generally used
            //return LocalRedirect("store/books/{bookId}");
            //return LocalRedirectPermanent("store/books/{bookId}");

            //return Redirect($"store/books/{bookId}");
            //return RedirectPermanent($"store/books/{bookId}");
            return Content($"Book Id: {bookId}, Book: {book}", "text/plain");
        }
    }
}
