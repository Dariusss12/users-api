using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_api.Src.DTO;
using users_api.Src.Models;

namespace users_api.Src.Repositories.interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(int pageNumber, int pageSize);
        Task<User?> GetUser(Guid id);
        Task<User> CreateUser(CreateUserDto createUserDto);
        Task<bool> UpdateUser(Guid id, EditUserDto editUser);
        Task<bool> DeleteUser(Guid id);
        Task<User?> GetUserByEmail(string email);
    }
}