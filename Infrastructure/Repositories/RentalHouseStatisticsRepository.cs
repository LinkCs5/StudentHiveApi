using Microsoft.EntityFrameworkCore;

namespace StudentHive.Infrastructure.Repositories;

public partial class RentalHouseRepository

{
    public async Task<int> GetTotalRentalHouses(int idRental)
    {
        var totalRental = await _context.RentalHouses
        .Where(rental => rental.IdPublication == idRental)
        .CountAsync();

        return totalRental;
    }
}