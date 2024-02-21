using AutoMapper;
using Domain.DTO.QueryFilter;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.DTO;
using StudentHive.Domain.DTO.Create;
using StudentHive.Domain.DTO.QueryFilter;
using StudentHive.Domain.DtoUpdate;
using StudentHive.Domain.Entities;
using StudentHive.Service.Features.RentalHouses;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("StudentHive/api/[controller]")]
public class RentalHouseController : ControllerBase
{
    private readonly RentalHouseService _rentalHouseService;
    private readonly IMapper _mapper;

    public RentalHouseController(RentalHouseService rentalHouseService, IMapper mapper)
    {
        this._rentalHouseService = rentalHouseService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]RentalHouseQueryFilterDto queryFilterDto)
    {
        var rentalHouses = await _rentalHouseService.GetAllRentalHouses(queryFilterDto);
        var rentalhouseDto = _mapper.Map<IEnumerable<RentalHouseDto>>(rentalHouses);

        return Ok(rentalhouseDto);
    }

    // [HttpGet("totalRentalHouses")]
    // public async Task<IActionResult> GetTotalRentalHouses(int idRental)
    // {
    //     StaticTotalRentalHousesDto totalRentalHousesDto = new()
    //     {
    //         TotalRentalHouses = await _rentalHouseService.GetTotalRentalHouses(idRental)
    //     };
    //     return Ok(totalRentalHousesDto);
    // }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var rentalhouse = await _rentalHouseService.GetById(id);
        if(rentalhouse.IdPublication <= 0)
        {
            return NotFound();
        }
        var dto = _mapper.Map<RentalHouseDto>(rentalhouse);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateRentalHouseDto rentalHouseDto)
    {

        var entity = _mapper.Map<RentalHouse>(rentalHouseDto);
        await _rentalHouseService.AddRentalHouse(entity);

        var dto = _mapper.Map<RentalHouseDto>(entity);

        return CreatedAtAction(nameof(GetById), new { id = entity.IdPublication }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRentalHouseDto updaterentalHouseDto)
    {
        try 
        {
            var entity = await _rentalHouseService.GetById(id);
            if(entity == null)
            {
                return NotFound();
            }
            entity.IdPublication = entity.IdPublication;
            entity.Title = updaterentalHouseDto.Title;
            entity.Description = updaterentalHouseDto.Description;
            entity.RentPrice = updaterentalHouseDto.RentPrice;
            entity.WhoElse = updaterentalHouseDto.WhoElse;
            entity.Status = updaterentalHouseDto.Status;
            entity.IdRentalHouseDetail = updaterentalHouseDto.IdRentalHouseDetail;
            entity.IdTypeHouseRental = updaterentalHouseDto.IdTypeHouseRental;
            entity.IdLocation = updaterentalHouseDto.IdLocation;
            entity.IdHouseService = updaterentalHouseDto.IdHouseService;
            await _rentalHouseService.UpdateRentalHouse(entity);
            return NoContent();
        }
        catch(Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var rentalhouse = await _rentalHouseService.GetById(id);
        if(rentalhouse == null)
        {
            NotFound();
        }
        await _rentalHouseService.DeleteRentalHouse(id);
        return NoContent();
    }
}