using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace SalesAutomationAPI.Data
{
    public class ValidPasswordAttribute : ValidationAttribute
    {
        private static readonly Regex MinimumLengthRegex = new Regex(@".{6,}", RegexOptions.Compiled);
        private static readonly Regex UpperCaseLetterRegex = new Regex(@"[A-Z]", RegexOptions.Compiled);
        private static readonly Regex NumberRegex = new Regex(@"\d", RegexOptions.Compiled);
        private static readonly Regex SpecialCharacterRegex = new Regex(@"[!@#$%^&*(),.?"":{}|<>]", RegexOptions.Compiled);
        private static readonly Regex WhiteSpaceRegex = new Regex(@"\s", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Password is required.");
            }

            if (!MinimumLengthRegex.IsMatch(password))
            {
                return new ValidationResult("Password must be at least 6 characters long.");
            }

            if (!UpperCaseLetterRegex.IsMatch(password))
            {
                return new ValidationResult("Password must contain at least one uppercase letter.");
            }

            if (NumberRegex.Matches(password).Count < 2)
            {
                return new ValidationResult("Password must contain at least two numbers.");
            }

            if (!SpecialCharacterRegex.IsMatch(password))
            {
                return new ValidationResult("Password must contain at least one special character.");
            }

            if (WhiteSpaceRegex.IsMatch(password))
            {
                return new ValidationResult("Password cannot contain white spaces.");
            }

            return ValidationResult.Success;
        }
    }
}
