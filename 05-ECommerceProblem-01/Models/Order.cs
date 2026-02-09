//using System.Net.Http.Headers;

using _05_ECommerceProblem_01.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _05_ECommerceProblem_01.Models
{
    public class Order
    {
        //[Required(ErrorMessage = "{0} cannot be empty or null")]
        [BindNever]
        [UnsettableByUserValidation]
        [Range(1, 99999, ErrorMessage = "{0} should be between {1} and {2}")]
        public int? OrderNo { get; set; }

        [DisplayName("Order Date")]
        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [MinimumDateRangeValidation("2001,1,1")]
        public DateTime? OrderDate { get; set; }

        [DisplayName("Invoice Price")]
        //[Required(ErrorMessage = "{0} cannot be empty or null")]
        // Add custom validator for the Invoice Price
        [InvoicePriceValidation("Products", ErrorMessage = "{0} (${1}) does not match the total price of Products (${2})")]
        public double InvoicePrice { get; set; }

        //[Required(ErrorMessage = "{0} cannot be empty or null")]
        [ProductsAmountValidation]
        public List<Product>? Products { get; set; }
    }
}
