using _04_BankingProblem.Data;
using _04_BankingProblem.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04_BankingProblem.Controllers
{
    public class HomeController : Controller
    {
        readonly Banks bankAccount = BankAccount01.BankAccount();

        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }

        [Route("/account-details")]
        public IActionResult Details()
        {
            //Banks bankAccount = BankAccount01.BankAccount();
            return Json(bankAccount);
        }

        [Route("/account-statement")]
        public IActionResult Statement()
        {
            return File("/sample.txt", "text/plain");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult CurrentBalance(int? accountNumber)
        {
            if (!accountNumber.HasValue)
            {
                return NotFound("Account Number should be supplied");
            }

            if (accountNumber != bankAccount.AccountNumber)
            {
                return BadRequest("Account Number should be correct");
            }
            else
            {
                return Content(Convert.ToString(bankAccount.CurrentBalance));
            }

            //return BadRequest("Invalid input. Try again.");
        }
    }
}
