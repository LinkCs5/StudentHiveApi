
using Microsoft.AspNetCore.Mvc;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.Publicaciones;
using AutoMapper;
using StudentHive.Domain.DTO;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route ("api/[Controller]")]
public class PublicacionesController : ControllerBase
{
    private readonly PublicacionesService _PublicacionesService;
    private readonly IMapper _mapper;

    public PublicacionesController (PublicacionesService publicacionesService, IMapper mapper)
    {
        this._mapper = mapper;
        this._PublicacionesService = publicacionesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var publicaciones = await _PublicacionesService.GetAll();
        var PublicacionesDtos = _mapper.Map<IEnumerable<PublicacionesDTO>>(publicaciones);

        return Ok(PublicacionesDtos);
    }
}