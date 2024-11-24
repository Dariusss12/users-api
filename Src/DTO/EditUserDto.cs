using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using users_api.Src.Validators;

namespace users_api.Src.DTO
{
    public class EditUserDto
    {
        
        [StringLength(15, ErrorMessage = "El nombre del usuario no puede tener más de 15 caracteres")]
        public string? Name { get; set; } = null;

        [StringLength(100, ErrorMessage = "Los apellidos del usuario no pueden tener más de 100 caracteres")]
        public string? LastName { get; set; } = null;

        [OptionalEmail]  
        [StringLength(100, ErrorMessage = "El correo electrónico del usuario no puede tener más de 100 caracteres")]
        public string? Email { get; set; } = null;

        [StringLength(30, ErrorMessage = "El contraseña del usuario no puede tener más de 30 caracteres")]
        public string? Password { get; set; } = null;

        public bool? IsActive { get; set; } = null;
    }
}