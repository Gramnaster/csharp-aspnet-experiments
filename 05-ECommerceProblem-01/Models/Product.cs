using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _05_ECommerceProblem_01.Models
{
    public class Product
    {
        [DisplayName("Product Code")]
        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} cannot be below 1 or above the maximum integer limit.")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} cannot be below 1 or above the maximum integer limit.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} cannot be below 1 or above the maximum integer limit.")]
        public int Quantity { get; set; }

    }
}
