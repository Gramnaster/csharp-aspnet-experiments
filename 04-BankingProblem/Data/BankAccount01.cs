using _04_BankingProblem.Models;
using System.Reflection.Metadata.Ecma335;

namespace _04_BankingProblem.Data
{
    public class BankAccount01
    {
        public static Banks BankAccount()
        {
            return new Banks ()
            {
                AccountNumber = 1001,
                AccountHolderName = "John Name",
                CurrentBalance = 5000
            };
        }
    }
}
