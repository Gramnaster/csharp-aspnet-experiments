using System.ComponentModel.DataAnnotations;

namespace _05_ECommerceProblem_01.CustomValidators
{
    public class MinimumDateRangeValidationAttribute : ValidationAttribute
    {
        public DateTime MinimumDate { get; set; } = new DateTime(2001, 1, 1);

        public MinimumDateRangeValidationAttribute(string minimumDate)
        {
            if (!DateTime.TryParse(minimumDate, out DateTime dateResult))
            {
                throw new ArgumentException("Invalid date format. Use a valid string.");
            }
            else
            {
                MinimumDate = dateResult;
            }
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            String? valueName = validationContext.DisplayName;

            if (value == null)
            {
                return new ValidationResult($"{valueName} cannot be null or empty");
            }

            //if (!DateTime.TryParse((string)value, out DateTime currentDate))
            if (value is not DateTime currentDate)
            {
                return new ValidationResult($"{valueName} is not a valid date");
            }

            if (currentDate < MinimumDate)
            {
                return new ValidationResult(ErrorMessage ?? $"{valueName} ({value:yyyy-MM-dd}) needs to be later than {MinimumDate:yyyy-MM-dd}");
            }

            return ValidationResult.Success;
        }
    }
}
