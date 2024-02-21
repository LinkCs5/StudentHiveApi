using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.DTO;
using StudentHive.Domain.DTO.Create;
using StudentHive.Domain.DTO.Login;
using StudentHive.Domain.DTO.Publitation;
using StudentHive.Domain.DtoUpdate;
using StudentHive.Domain.Entities;
using StudentHive.Service.Features.Users;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;

	public UserController(UserService services,IMapper mapper)
    {
        this._mapper = mapper;
        this._userService = services;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GeById(id);
        if(user.IdUser <= 0)return NotFound();

        var dto = _mapper.Map<UserDto>(user);
        return Ok(dto);
        
    }

[HttpGet("publication/{id}")]
public async Task<IActionResult> GetAllPublicationsOfOneuser(int id)
{
    var users = await _userService.GetAllPublicationsOfOneUser(id);
    if(users == null || users.Count == 0) return NotFound();

    // Por ejemplo, puedes acceder al primer usuario en la lista
    var firstUser = users.FirstOrDefault();
    if(firstUser!.IdUser <= 0) return NotFound();

    var dto = _mapper.Map<PublicationUsersDto>(firstUser);
    return Ok(dto);
}



    [HttpPost("login")]
    public async Task<IActionResult> Login (UserLoginDto userLogin)
    {
        if(userLogin.Email == null || userLogin.Password == null) return BadRequest();

        var entity = await _userService.AuthLogin(userLogin.Email, userLogin.Password);
        var dto = _mapper.Map<UserDto>(entity);
        return CreatedAtAction(nameof(GetUserById), new {id = entity.IdUser}, dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateUserDto user)
    {
        var entity = _mapper.Map<User>(user);
        await _userService.Add(entity);

        var dto = _mapper.Map<UserDto>(entity);
        return CreatedAtAction(nameof(GetUserById), new {id = entity.IdUser}, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto user)
    {
           if (id <= 0)
        {
            return BadRequest();
        }

        var entity = _mapper.Map<User>(user);
        entity.IdUser = id;

        await _userService.Update(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userService.GeById(id);
        if(user == null)
        {
            return NotFound();
        }
        await _userService.Delete(id);
        return NoContent();
    }

}
