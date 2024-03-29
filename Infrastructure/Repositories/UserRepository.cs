using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;


namespace StudentHive.Infrastructure.Repositories;

public class UserRepository
{
    private readonly StudentHiveApiDbContext _context;

    public UserRepository(StudentHiveApiDbContext context)
    {
        this._context = context;
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.IdUser == id);
        return user ?? new User();
    }

    public async Task<List<User>> GetAllPublicationsOfOneUser(int id)
    {
        var user = await _context.Users
            .Include(user => user.RentalHouses)
            .Where(user => user.IdUser == id).ToListAsync();
        return user;
    }
    public async Task<User> AtuhLogin(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        return user ?? new User();
    }

    public async Task AddUser(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User updatedUser)
    {
        var user = await _context.Users.FirstOrDefaultAsync(User => User.IdUser == updatedUser.IdUser);

        if(user != null)
        {
            _context.Entry(user).CurrentValues.SetValues(updatedUser);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(User => User.IdUser == id);
        if(user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}