using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace users_api.Src.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}