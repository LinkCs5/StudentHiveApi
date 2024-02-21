using StudentHive.Domain.DTO.QueryFilter;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Service.Features.RentalHouses;

public class RentalHouseService
{
    private readonly RentalHouseRepository _rentalHouseRepository;

    public RentalHouseService(RentalHouseRepository rentalHouseRepository)
    {
        this._rentalHouseRepository = rentalHouseRepository;
    }

    public async Task<IEnumerable<RentalHouse>> GetAllRentalHouses(RentalHouseQueryFilterDto queryFilterDto)
    {
        return await _rentalHouseRepository.GetAllRentalHouses(queryFilterDto);
    }

    public async Task<int> GetTotalRentalHouses(int idRental)
    {
        return await _rentalHouseRepository.GetTotalRentalHouses(idRental);
    }

    public async Task<RentalHouse> GetById(int id)
    {
        return await _rentalHouseRepository.GtById(id);
    }

    public async Task<RentalHouse> AddRentalHouse(RentalHouse rentalHouse)
    {
        return await _rentalHouseRepository.AddRentalHouse(rentalHouse);
    }

    public async Task UpdateRentalHouse(RentalHouse updaterentalHouse)
    {
        var rentalHouse = await GetById(updaterentalHouse.IdPublication);
        if(rentalHouse.IdPublication >0)
        {
            await _rentalHouseRepository.UpdateRentalHouse(updaterentalHouse);
        }
    }

    public async Task DeleteRentalHouse(int id)
    {
        var rentalHouse = await GetById(id);
        if(rentalHouse.IdPublication >0)
        {
            await _rentalHouseRepository.DeleteRentalHouse(id);
        }
    }
}