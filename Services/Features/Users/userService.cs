using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repository;

namespace StudentHive.Services.Features.Users
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
        }


        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
            
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}