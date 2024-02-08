
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.DTO;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.RentalH;

namespace StudentHive.Controllers.V1;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/V1/[controller]")]
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
    public async Task<IActionResult> UpdateRentalHouse([FromBody] RentalHouseDto RentalHouseDto, int id)
    {
        try
        {
            var existingRentalHouse = await _rentalHouseService.GetRentalHouseById(id);
            if (existingRentalHouse == null)
            {
                return NotFound();
            }
            existingRentalHouse.Title = RentalHouseDto.Title;
            existingRentalHouse.Description = RentalHouseDto.Description;
            existingRentalHouse.Status = RentalHouseDto.Status;
            existingRentalHouse.WhoElse = RentalHouseDto.WhoElse;
            existingRentalHouse.RentPrice = RentalHouseDto.RentPrice;

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