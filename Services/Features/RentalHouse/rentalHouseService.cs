using StudentHive.Infrastructure.Repository;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Features.RentalH;

public class RentalHouseService
{
    private readonly RentalHouseRepository _rentalHouseRepository;

    public RentalHouseService(RentalHouseRepository rentalHouseRepository)
    {
        this._rentalHouseRepository = rentalHouseRepository;
    }

    public async Task<IEnumerable<RentalHouse>> GetRentalHouses()
    {
        return await _rentalHouseRepository.GetRentalHouses();
    }

    public async Task<RentalHouse> GetRentalHouseById(int id)
    {
        return await _rentalHouseRepository.GetRentalHouseById(id);
    }
    public async Task CreateRentalHouse(RentalHouse rentalHouse)
    {
        await _rentalHouseRepository.CreateRentalHouse(rentalHouse);
    }
    public async Task UpdateRentalHouse(RentalHouse updateRentalHouse)
    {
        await _rentalHouseRepository.UpdateRentalHouse(updateRentalHouse);
    }
    public async Task DeleteRentalHouse(int id)
    {
        await _rentalHouseRepository.DeleteRentalHouse(id);
    }
}