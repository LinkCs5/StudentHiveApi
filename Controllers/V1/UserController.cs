using AutoMapper;
using StudentHive.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Entities;
using StudentHive.Domain.DtoUpdate;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/V1/[controller]")]
public class UserController : ControllerBase 
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await _userService.CreateUser(user);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUser userDto, int id)
    {
        try
        {
            var existingUser = await _userService.GetUserById(id);
            if(existingUser == null)
            {
                return NotFound();
            }
            existingUser.IdUser = userDto.IdUser;
            existingUser.Name = userDto.Name;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.Password = userDto.Password;
            existingUser.UserAge = userDto.UserAge;
            existingUser.Description = userDto.Description;
            existingUser.PhoneNumber = userDto.PhoneNumber;
            existingUser.ProfilePhotoUrl = userDto.ProfilePhotoUrl;
            existingUser.Genderu = userDto.Genderu;

            await _userService.UpdateUser(existingUser);

            return NoContent();
        }
        catch(Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUser(id);
        return Ok();
    }
    
}