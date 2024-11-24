using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using users_api.Src.Data;
using users_api.Src.DTO;
using users_api.Src.Models;
using users_api.Src.Repositories.interfaces;

namespace users_api.Src.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        private readonly DataContext _context = context;

        public Task<User> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(Guid id, EditUserDto editUser)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if(existingUser == null){
                return false;
            }

            existingUser.Name = editUser.Name ?? existingUser.Name;
            existingUser.LastName = editUser.LastName ?? existingUser.LastName;
            existingUser.Email = editUser.Email ?? existingUser.Email;
            existingUser.Password = editUser.Password ?? existingUser.Password;
            existingUser.IsActive = editUser.IsActive ?? existingUser.IsActive;


            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if(existingUser == null){
                return false;
            }
            existingUser.IsActive = false;


            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}