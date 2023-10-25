using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Reservas;
using AutoMapper;
using StudentHive.Domain.Dtos;
using Microsoft.AspNetCore.Identity;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route ("api/[controller]")]
public class ReservaController : ControllerBase
{
    private readonly ReservacionesService _reservaService;
    private readonly IMapper _mapper;

    public ReservaController(ReservacionesService reservaService, IMapper mapper) 
    {
        this._reservaService = reservaService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservas = await _reservaService.GetAll();
        var reservaDTos = _mapper.Map<IEnumerable<ReservaDTO>>(reservas);
        
        return Ok(reservaDTos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var reserva = await _reservaService.GetById(id);
        if(reserva.IdReservas <= 0)
        return NotFound();

        var dto = _mapper.Map<ReservaDTO>(reserva);

        return Ok (dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ReservaCreateDTO reserva)
    {
        var entity = _mapper.Map<Reserva>(reserva);

        await _reservaService.Add(entity);
        var dto = _mapper.Map<ReservaDTO>(entity);

        return CreatedAtAction(nameof(GetById),new {id = entity.IdReservas},dto);
    }

    
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     await _reservaService.Delete(id);
    //     return NoContent();
    // }
}