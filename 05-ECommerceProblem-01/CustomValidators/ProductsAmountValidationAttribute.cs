using _05_ECommerceProblem_01.Models;
using System.ComponentModel.DataAnnotations;

namespace _05_ECommerceProblem_01.CustomValidators
{
    public class ProductsAmountValidationAttribute : ValidationAttribute
    {
        private readonly int? _minCount = 1;
        private readonly int? _maxCount = int.MaxValue;

        //public ProductsAmountValidationAttribute(int minCount, int maxCount)
        //{
        //    _minCount = minCount;
        //    _maxCount = maxCount;
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? valueName = validationContext.DisplayName;
            if (value == null)
            {
                return new ValidationResult($"{valueName} cannot be null or empty");
            }

            if (value is not List<Product>)
            {
                return new ValidationResult($"{valueName} must be a valid collection");
            }

            List<Product> products = (List<Product>)value;

            if (products.Count < _minCount || products.Count > _maxCount)
            {
                return new ValidationResult($"{valueName} must contain between {_minCount} and {_maxCount}. Current count: {products.Count}");
            }
            
            return ValidationResult.Success;
        }
    }
}
