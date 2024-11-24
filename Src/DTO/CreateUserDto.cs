using System.ComponentModel.DataAnnotations;

namespace users_api.Src.DTO
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [MinLength(3, ErrorMessage = "El nombre del usuario debe tener al menos 3 caracteres")]
        [MaxLength(15, ErrorMessage = "El nombre del usuario no puede tener más de 15 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [MinLength(3, ErrorMessage = "Los apellidos usuario deben tener al menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Los apellidos del usuario no pueden tener más de 100 caracteres")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico del usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [MaxLength(100, ErrorMessage = "El correo electrónico del usuario no puede tener más de 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El contraseña del usuario es obligatorio")]
        [MinLength(3, ErrorMessage = "La contraseña del usuario debe tener al menos 3 caracteres")]
        [MaxLength(30, ErrorMessage = "La contraseña del usuario no puede tener más de 30 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}