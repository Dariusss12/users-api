using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace users_api.Src.DTO
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [StringLength(15, ErrorMessage = "El nombre del usuario no puede tener más de 15 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        [StringLength(100, ErrorMessage = "Los apellidos del usuario no pueden tener más de 100 caracteres")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico del usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(100, ErrorMessage = "El correo electrónico del usuario no puede tener más de 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El contraseña del usuario es obligatorio")]
        [StringLength(30, ErrorMessage = "El contraseña del usuario no puede tener más de 30 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}