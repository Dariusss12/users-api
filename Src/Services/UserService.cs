using users_api.Src.DTO;
using users_api.Src.Repositories.interfaces;
using users_api.Src.Services.interfaces;

namespace users_api.Src.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<UserDto> GetUser(Guid id)
        {
            var existingUser = await _userRepository.GetUser(id);
            if(existingUser == null){
                return null;
            }
            return new UserDto
            {
                Id = existingUser.Id,
                Name = existingUser.Name,
                LastName = existingUser.LastName,
                Email = existingUser.Email,
                IsActive = existingUser.IsActive
            };
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive
            });
        }
        public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            var existingUser = await _userRepository.GetUserByEmail(createUserDto.Email);
            if(existingUser != null){
                throw new Exception("El correo ingresado ya existe en el sistema");
            }
            var result = await _userRepository.CreateUser(createUserDto);

            return new UserDto
            {
                Id = result.Id,
                Name = result.Name,
                LastName = result.LastName,
                Email = result.Email,
                IsActive = result.IsActive
            };
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