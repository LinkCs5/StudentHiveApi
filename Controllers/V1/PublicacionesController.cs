using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using  StudentHive.Services.Features.Publicaciones;

namespace StudentHive0.Controllers.V1;

[ApiController]
[Route ("api/[controller]")]
public class PublicacionController : ControllerBase
{

    private readonly PublicacionesService _publicacionService;
    private readonly IMapper _mapper;

    public PublicacionController(PublicacionesService publicacionService, IMapper mapper)
    {
        this._publicacionService = publicacionService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var publicaciones = await _publicacionService.GetAll();

        var publicacionesDtos = _mapper.Map<IEnumerable<PublicacionesDTO>>(publicaciones);
        return Ok(publicacionesDtos);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById (int id)
    // {
    //     var publicacion = await _publicacionService.GetById(id);
    //     if(publicacion.IdPublicacion <= 0)
    //     {
    //         return NotFound();
    //     }
    //     var dto = _mapper.Map<PublicacionesDTO>(publicacion);

    //     return Ok(dto);
    // }

    // [HttpPost]
    // public async Task<IActionResult> Add (PublicacionesCreateDTO publicacion)
    // {
    //     var entity = _mapper.Map<Publicacion>(publicacion);

    //     await _publicacionService.Add(entity);

    //     var dto = _mapper.Map<PublicacionesDTO>(entity);

    //     return CreatedAtAction (nameof(GetById), new {id = entity.IdPublicacion}, dto );

    // }
}