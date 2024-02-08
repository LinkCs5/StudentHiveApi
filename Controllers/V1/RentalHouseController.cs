using AutoMapper;
using StudentHive.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Entities;
using StudentHive.Domain.DtoUpdate;
using StudentHive.Services.Features.RentalH;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/V1/[controller]")]
public class rentalHouseController : ControllerBase
{
    private readonly RentalHouseService _rentalHouseService;
    private readonly IMapper _mapper;

    public rentalHouseController(RentalHouseService rentalHouseService, IMapper mapper)
    {
        _rentalHouseService = rentalHouseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRentalHouses()
    {
        var rentalHouses = await _rentalHouseService.GetRentalHouses();
        return Ok(rentalHouses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRentalHouseById(int id)
    {
        var rentalHouse = await _rentalHouseService.GetRentalHouseById(id);
        return Ok(rentalHouse);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRentalHouse([FromBody] RentalHouseDto RentalHouseDto)
    {
        var rental = _mapper.Map<RentalHouse>(RentalHouseDto);
        await _rentalHouseService.CreateRentalHouse(rental);
        return Ok(rental);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRentalHouse([FromBody] UpdateRentalHouseDto updateRentalHouseDto, int id)
    {
        try
        {
            var existingRentalHouse = await _rentalHouseService.GetRentalHouseById(id);
            if (existingRentalHouse == null)
            {
                return NotFound();
            }
            existingRentalHouse.Title = updateRentalHouseDto.Title;
            existingRentalHouse.Description = updateRentalHouseDto.Description;
            existingRentalHouse.Status = updateRentalHouseDto.Status;
            existingRentalHouse.WhoElse = updateRentalHouseDto.WhoElse;
            existingRentalHouse.RentPrice = updateRentalHouseDto.RentPrice;

            await _rentalHouseService.UpdateRentalHouse(existingRentalHouse);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRentalHouse(int id)
    {
        await _rentalHouseService.DeleteRentalHouse(id);
        return NoContent();
    }
}