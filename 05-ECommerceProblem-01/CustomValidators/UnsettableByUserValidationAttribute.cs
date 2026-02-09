using System.ComponentModel.DataAnnotations;

namespace _05_ECommerceProblem_01.CustomValidators
{
    public class UnsettableByUserValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                return new ValidationResult($"{validationContext.DisplayName} must not be present in the form.");
            }

            return ValidationResult.Success;
        }
    }
}
