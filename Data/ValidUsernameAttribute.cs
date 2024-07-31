using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace SalesAutomationAPI.Data
{
    public class ValidUsernameAttribute : ValidationAttribute
    {
        private static readonly Regex UsernameRegex = new Regex("^[a-zA-Z0-9]+$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var username = value as string;
            if (string.IsNullOrEmpty(username))
            {
                return new ValidationResult("Username is required.");
            }

            if (!UsernameRegex.IsMatch(username))
            {
                return new ValidationResult("Username can only contain letters and numbers, with no spaces or special characters.");
            }

            return ValidationResult.Success;
        }
    }
}
