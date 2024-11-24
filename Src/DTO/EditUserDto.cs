using System.ComponentModel.DataAnnotations;
using users_api.Src.Validators;

namespace users_api.Src.DTO
{
    public class EditUserDto
    {
        [MinLength(3, ErrorMessage = "El nombre del usuario debe tener al menos 3 caracteres")]
        [MaxLength(15, ErrorMessage = "El nombre del usuario no puede tener más de 15 caracteres")]
        public string? Name { get; set; } = null;

        [MinLength(3, ErrorMessage = "El nombre del usuario debe tener al menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Los apellidos del usuario no pueden tener más de 100 caracteres")]
        public string? LastName { get; set; } = null;

        [OptionalEmail]  
        [MaxLength(100, ErrorMessage = "El correo electrónico del usuario no puede tener más de 100 caracteres")]
        public string? Email { get; set; } = null;

        [MinLength(3, ErrorMessage = "El nombre del usuario debe tener al menos 3 caracteres")]
        [MaxLength(30, ErrorMessage = "El contraseña del usuario no puede tener más de 30 caracteres")]
        public string? Password { get; set; } = null;

        public bool? IsActive { get; set; } = null;
    }
}