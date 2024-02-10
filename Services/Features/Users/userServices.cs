using System.Runtime.Intrinsics.Arm;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Service.Features.Users;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<User> GeById( int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<User> AuthLogin(string email, string password)
    {
        return await _userRepository.AtuhLogin(email, password);
    }

    public async Task Add(User user)
    {
        await _userRepository.AddUser(user);
    }

    public async Task Update(User userUpdate)
    {
        var user = await GeById(userUpdate.IdUser);
        if(user.IdUser > 0)
        {
            await _userRepository.UpdateUser(userUpdate);
        }
    }

    public async Task Delete(int id)
    {
        var user = await GeById(id);
        if(user.IdUser > 0)
        {
            await _userRepository.Delete(id);
        }
    }
}