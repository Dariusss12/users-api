using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_api.Src.DTO;

namespace users_api.Src.Services.interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUser(Guid id);

        Task<UserDto> CreateUser(CreateUserDto createUser);

        Task<bool> UpdateUser(Guid id, EditUserDto editUser);

        Task<bool> DeleteUser(Guid id);
        
    }
}