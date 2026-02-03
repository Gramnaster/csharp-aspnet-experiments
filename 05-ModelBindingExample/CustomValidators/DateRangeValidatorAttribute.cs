using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _05_ModelBindingExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public DateRangeValidatorAttribute(string otherPropertName)
        {
            OtherPropertyName = otherPropertName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                DateTime toDate = Convert.ToDateTime(value);
                // Object Instance is based on the object sent through Model Binding
                // otherProperty represents FromDate
                // Uses 'Reflection'
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    object? otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

                    if (otherValue is not null)
                    {
                        DateTime fromDate = Convert.ToDateTime(otherValue);

                        if (fromDate > toDate)
                        {
                            // Fix CS8601: Ensure validationContext.MemberName is not null
                            // Fix IDE0300: Use collection initializer
                            return new ValidationResult(
                                ErrorMessage ?? "Invalid date range.",
                                [OtherPropertyName, validationContext.MemberName ?? string.Empty]
                            );
                        }
                        else
                        {
                            return ValidationResult.Success;
                        }
                    }
                }
            }
            return null;
        }
    }
}
