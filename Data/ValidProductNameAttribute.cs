using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace SalesAutomationAPI.Data
{
    public class ValidProductNameAttribute : ValidationAttribute
    {
        private static readonly Regex ProductRegex = new Regex("^[a-zA-Z0-9]+$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var productname = value as string;
            if (string.IsNullOrEmpty(productname))
            {
                return new ValidationResult("Product Name is required.");
            }

            if (!ProductRegex.IsMatch(productname))
            {
                return new ValidationResult("Product Name can only contain letters and numbers, with no spaces or special characters.");
            }

            return ValidationResult.Success;
        }
    }
}
