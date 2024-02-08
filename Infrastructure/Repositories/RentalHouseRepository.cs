using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;

namespace StudentHive.Infrastructure.Repository;

public class RentalHouseRepository
{
    private readonly StudentHiveApiDbContext _context;
    public RentalHouseRepository(StudentHiveApiDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<RentalHouse>> GetRentalHouses()
    {
        var rentalHouses = await _context.RentalHouses.ToListAsync();
        return rentalHouses;
    }
    public async Task<RentalHouse> GetRentalHouseById(int id)
    {
        var rentalHouse = await _context.RentalHouses.FindAsync(id);
        return rentalHouse ?? new RentalHouse();
    }
    public async Task CreateRentalHouse(RentalHouse rentalHouse)
    {
        await _context.RentalHouses.AddAsync(rentalHouse);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateRentalHouse(RentalHouse updateRentalHouse)
    {
        _context.RentalHouses.Update(updateRentalHouse);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteRentalHouse(int id)
    {
        var rentalHouse = await _context.RentalHouses.FirstOrDefaultAsync(x => x.IdPublication == id);
        if (rentalHouse != null)
        {
            _context.RentalHouses.Remove(rentalHouse);
            await _context.SaveChangesAsync();
        }
    }
}