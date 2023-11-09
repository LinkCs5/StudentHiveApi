
using System.ComponentModel;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.DTO;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Matchs;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class MatchsController : ControllerBase
{
    private readonly  MatchService _matchService;
    private readonly IMapper _mapper;

    public MatchsController (MatchService matchService, IMapper mapper)
    {
        this._mapper = mapper;
        this._matchService = matchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var matchs = await _matchService.GetAll();
        var matchDtos = _mapper.Map<IEnumerable<MatchsDTO>>(matchs);

        return Ok(matchDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById (int id)
    {
        var matchs = await _matchService.GetById(id);

        if(matchs.IdMatch <= 0)
        return NotFound();

        var dto = _mapper.Map<MatchsDTO>(matchs);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateMatchsDTO match)
    {
        var entity = _mapper.Map<StudentHive.Domain.Entities.Match>(match);

        await _matchService.Add(entity);

        var dto = _mapper.Map<MatchsDTO>(entity);

        return CreatedAtAction(nameof(GetById),new {id = entity.IdMatch}, dto);
    }



}
