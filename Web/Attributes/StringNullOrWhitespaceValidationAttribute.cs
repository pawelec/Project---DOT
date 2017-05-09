using System.ComponentModel.DataAnnotations;

namespace Web.Attributes
{
    public class StringNullOrWhitespaceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string str = value?.ToString();
            if (string.IsNullOrWhiteSpace(str))
                return new ValidationResult("Wartość musi zostać uzupełniona.");
            return ValidationResult.Success;
        }
    }
}