using _05_ModelBindingExample.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _05_ModelBindingExample.Models
{
    public class Person : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Person Name")]
        [Required(ErrorMessage = "{0} cannot be empty or null.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters.")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, spaces, and periods.")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty or null")]
        [EmailAddress(ErrorMessage = "{0} should be a valid email address.")]
        public string? Email {  get; set; }

        [Phone(ErrorMessage = "{0} should contain only digits.")]
        //[ValidateNever]
        public string? Phone {  get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password {  get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword {  get; set; }

        //[MinimumYearValidator(2005, ErrorMessage = "Date of Birth should be before {0}")]
        [MinimumYearValidator(2005)]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }
        [DateRangeValidator("FromDate", ErrorMessage = "From Date should be older than or equal to the To Date")]
        public DateTime? ToDate { get; set;  }

        [Range(0, 999, ErrorMessage = "{0} should be between {1} and {2}.")]
        public double? Price {  get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {PersonName} | Email: {Email} | Phone: {Phone} | Password: {Password} | Confirm Password: {ConfirmPassword} | Price: {Price} | Date of Birth: {DateOfBirth}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!DateOfBirth.HasValue && !Age.HasValue)
            {
                yield return new ValidationResult("Either Date of Birth or Age must be supplied", new[] { nameof(Age)});
            }

            //if ()
        }
    }
}
