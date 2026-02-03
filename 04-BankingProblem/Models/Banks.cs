namespace _04_BankingProblem.Models
{
    public class Banks
    {
        public int AccountNumber { get; set; }
        public string? AccountHolderName { get; set; }
        public decimal CurrentBalance { get; set; } = 0;
    }
}
