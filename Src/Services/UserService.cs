using users_api.Src.DTO;
using users_api.Src.Repositories.interfaces;
using users_api.Src.Services.interfaces;

namespace users_api.Src.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        public Task<UserDto> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetUsers()
        {
            throw new NotImplementedException();
        }
        public Task<UserDto> CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(Guid id, EditUserDto editUser)
        {
            if(editUser.Email != null)
            {
                var existingUser = await _userRepository.GetUserByEmail(editUser.Email);
                if(existingUser != null)
                {
                    throw new Exception("El correo ingresado ya existe en el sistema");
                }
            }
            var result = await _userRepository.UpdateUser(id, editUser);
            return result;
        }
        
        public async Task<bool> DeleteUser(Guid id)
        {
            var result = await _userRepository.DeleteUser(id);
            return result;
        }
    }
}