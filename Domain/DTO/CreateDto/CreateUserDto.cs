namespace StudentHive.Domain.DTO.Create;

public class CreateUserDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int UserAge { get; set; }
}