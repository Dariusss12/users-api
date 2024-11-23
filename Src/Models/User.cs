using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace users_api.Src.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}