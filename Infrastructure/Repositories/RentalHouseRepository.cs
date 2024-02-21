using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.DTO.QueryFilter;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;

namespace StudentHive.Infrastructure.Repositories;

public partial class RentalHouseRepository
{
    private readonly StudentHiveApiDbContext _context;
    public RentalHouseRepository(StudentHiveApiDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<RentalHouse>> GetAllRentalHouses(RentalHouseQueryFilterDto QueryFilterDto)
    {
        var  query =  _context.RentalHouses
            .Include(r => r.IdHouseServiceNavigation)
            .Include(r => r.IdLocationNavigation)
            .Include(r => r.IdRentalHouseDetailNavigation)
            .Include(r => r.IdTypeHouseRentalNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.Images)
        .AsQueryable();

        if(QueryFilterDto.IdRentalHouse > 0 )
        query = query.Where(rentalHouse => rentalHouse.IdPublication == QueryFilterDto.IdRentalHouse);

        if(QueryFilterDto.Status == true)
        query = query.Where(rentalhouse => rentalhouse.Status == QueryFilterDto.Status); 

        if(!string.IsNullOrEmpty(QueryFilterDto.WhoElse) && !string.IsNullOrWhiteSpace(QueryFilterDto.WhoElse))
        query = query.Where(rentalHouse => rentalHouse.WhoElse.Contains(QueryFilterDto.WhoElse));

        if(QueryFilterDto.RentPrice > 0)
        query = query.Where(RentalHouse => RentalHouse.RentPrice == QueryFilterDto.RentPrice);

        if(QueryFilterDto.PublicationDate > DateTime.MinValue)
        query = query.Where(rentalHouse => rentalHouse.PublicationDate == QueryFilterDto.PublicationDate);

        if(QueryFilterDto.Wifi == true)
        query = query.Where(rentalHouse => rentalHouse.IdHouseServiceNavigation!.Wifi == QueryFilterDto.Wifi);

        if(QueryFilterDto.Kitchen == true)
        query = query.Where(rentalhouse => rentalhouse.IdHouseServiceNavigation!.Kitchen == QueryFilterDto.Kitchen);

        if(QueryFilterDto.Washer == true)
        query = query.Where(rentalHouse => rentalHouse.IdHouseServiceNavigation!.Washer == QueryFilterDto.Washer);

        if(QueryFilterDto.AirConditioning == true)
        query = query.Where(rentalHouse => rentalHouse.IdHouseServiceNavigation!.AirConditioning == QueryFilterDto.AirConditioning);

        if(QueryFilterDto.Water == true)
        query = query.Where(rentalHouse => rentalHouse.IdHouseServiceNavigation!.Water == QueryFilterDto.Water);

        if(QueryFilterDto.Gas == true)
        query = query.Where(rentalHouse => rentalHouse.IdHouseServiceNavigation!.Gas == QueryFilterDto.Gas);

        if(QueryFilterDto.Television == true)
        query = query.Where(rentalHouse => rentalHouse.IdHouseServiceNavigation!.Television == QueryFilterDto.Television);

        if(!string.IsNullOrEmpty(QueryFilterDto.Address) && !string.IsNullOrWhiteSpace(QueryFilterDto.Address))
        query = query.Where(rentalHouse => rentalHouse.IdLocationNavigation!.Address.Contains(QueryFilterDto.Address));

        if(!string.IsNullOrEmpty(QueryFilterDto.City) && !string.IsNullOrWhiteSpace(QueryFilterDto.City))
        query = query.Where(rentalHouse => rentalHouse.IdLocationNavigation!.City.Contains(QueryFilterDto.City));

        if(!string.IsNullOrEmpty(QueryFilterDto.State) && !string.IsNullOrWhiteSpace(QueryFilterDto.State))
        query = query.Where(rentalHouse => rentalHouse.IdLocationNavigation!.State.Contains(QueryFilterDto.State));

        if(!string.IsNullOrEmpty(QueryFilterDto.Country) && !string.IsNullOrWhiteSpace(QueryFilterDto.Country))
        query = query.Where(rentalHouse => rentalHouse.IdLocationNavigation!.Country.Contains(QueryFilterDto.Country));

        if(QueryFilterDto.PostalCode > 0)
        query = query.Where(rentalHouse => rentalHouse.IdLocationNavigation!.PostalCode == QueryFilterDto.PostalCode);

        if(!string.IsNullOrEmpty(QueryFilterDto.Neighborhood) && !string.IsNullOrWhiteSpace(QueryFilterDto.Neighborhood))
        query = query.Where(rentalHouse => rentalHouse.IdLocationNavigation!.Neighborhood!.Contains(QueryFilterDto.Neighborhood));

        if(QueryFilterDto.NumberOfGuests > 0)
        query = query.Where(rentalHouse => rentalHouse.IdRentalHouseDetailNavigation!.NumberOfGuests == QueryFilterDto.NumberOfGuests);

        if(QueryFilterDto.NumberOfBathrooms > 0)
        query = query.Where(rentalHouse => rentalHouse.IdRentalHouseDetailNavigation!.NumberOfBathrooms == QueryFilterDto.NumberOfBathrooms);

        if(QueryFilterDto.NumberOfRooms > 0)
        query = query.Where(rentalHouse => rentalHouse.IdRentalHouseDetailNavigation!.NumberOfRooms == QueryFilterDto.NumberOfRooms);

        if(QueryFilterDto.NumbersOfBed > 0)
        query = query.Where(rentalHouse => rentalHouse.IdRentalHouseDetailNavigation!.NumbersOfBed == QueryFilterDto.NumbersOfBed);

        if(QueryFilterDto.NumberOfHammocks > 0)
        query = query.Where(rentalHouse => rentalHouse.IdRentalHouseDetailNavigation!.NumberOfHammocks == QueryFilterDto.NumberOfHammocks);

        if(QueryFilterDto.OwnHouse == true)
        query = query.Where(rentalHouse => rentalHouse.IdTypeHouseRentalNavigation!.OwnHouse == QueryFilterDto.OwnHouse);

        if(QueryFilterDto.SharedRoom == true)
        query = query.Where(rentalHouse => rentalHouse.IdTypeHouseRentalNavigation!.SharedRoom == QueryFilterDto.SharedRoom);

        if(QueryFilterDto.SingleRoom == true)
        query = query.Where(rentalHouse => rentalHouse.IdTypeHouseRentalNavigation!.SingleRoom == QueryFilterDto.SingleRoom);

        var rentalHouse = await query.ToListAsync();

        return rentalHouse;
    }

    public async Task<RentalHouse> GtById (int id)
    {
        var rentalhouse = await _context.RentalHouses
            .Include(r => r.IdHouseServiceNavigation)
            .Include(r => r.IdLocationNavigation)
            .Include(r => r.IdRentalHouseDetailNavigation)
            .Include(r => r.IdTypeHouseRentalNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.Images)
            .FirstOrDefaultAsync(rental => rental.IdPublication == id);
            return rentalhouse ?? new RentalHouse();
    }

    public async Task<RentalHouse> AddRentalHouse(RentalHouse rentalHouse)
    {
        _context.RentalHouses.Add(rentalHouse);
        await _context.SaveChangesAsync();
        return rentalHouse;
    }

    public async Task UpdateRentalHouse(RentalHouse updaterentalHouse)
    {
               var RentalHouse = await _context.RentalHouses.FirstOrDefaultAsync(rentalHouse => rentalHouse.IdPublication == updaterentalHouse.IdPublication);

        if (RentalHouse != null)
        {
            _context.Entry(RentalHouse).CurrentValues.SetValues(updaterentalHouse);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteRentalHouse(int id)
    {
        var rentalHouse = await _context.RentalHouses.FirstOrDefaultAsync(r => r.IdPublication == id); 
        if(rentalHouse != null)
        {
            _context.RentalHouses.Remove(rentalHouse);
            await _context.SaveChangesAsync();
        }
    }
} 