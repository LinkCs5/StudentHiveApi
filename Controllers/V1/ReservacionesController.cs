
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.DTO;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Reservaciones;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class ReservacionesController : ControllerBase
{
    private readonly ReservacionesService _reservacionesService;
    private readonly IMapper _mapper;
    
    public ReservacionesController (ReservacionesService reservacionesService, IMapper mapper)
    {
        this._mapper = mapper;
        this._reservacionesService = reservacionesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reservaciones = await _reservacionesService.GetAll();
        var reservacionesDtos =  _mapper.Map<IEnumerable<ResevacionesDTO>>(reservaciones);

        return Ok(reservacionesDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservacionesByInquilino( int id)
    {
        var reservaciones = await _reservacionesService.GetReservacionesByInquilino(id);

        if(reservaciones == null || reservaciones.Count == 0)
        return NotFound();

        var dto = _mapper.Map<List<ResevacionesDTO>>(reservaciones);

        return Ok(dto);
    }
    
    [HttpGet("ById/{id}")]
    public async Task<IActionResult> GetById( int id)
    {
        var reservaciones = await _reservacionesService.GetById(id);

        if(reservaciones.IdReserva <= 0)
        return NotFound();

        var dto = _mapper.Map<ResevacionesDTO>(reservaciones);

        return Ok(dto);
    }


    [HttpPost]
    public async Task<IActionResult> Add(CreateReservacionesDTO reserva)
    {
        var entity = _mapper.Map<Reservacion>(reserva);

        await _reservacionesService.Add(entity);

        var dto = _mapper.Map<ResevacionesDTO>(entity);
        return CreatedAtAction(nameof(GetById), new {id = entity.IdReserva}, dto);
    }
}