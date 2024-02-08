
namespace StudentHive.Domain.DTO;
public class UserDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int UserAge { get; set; }
    public DateTime PublicationDate { get; set; }


}