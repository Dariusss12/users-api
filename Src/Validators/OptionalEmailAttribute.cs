using System.ComponentModel.DataAnnotations;

namespace users_api.Src.Validators
{
    public class OptionalEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Si el valor es null o vacío, no hay error.
            if (string.IsNullOrEmpty(value as string))
            {
                return ValidationResult.Success;
            }

            // Validar formato del correo electrónico
            var emailAttribute = new EmailAddressAttribute();
            if (!emailAttribute.IsValid(value))
            {
                return new ValidationResult(ErrorMessage ?? "El correo electrónico no es válido");
            }

            return ValidationResult.Success;
        }
    }
}