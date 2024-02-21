namespace StudentHive.Domain.DTO.ReponseRentalHouseDto;

public class UserReponseDto
{
    public int IdUser {get; set; }
    public int? UserAge {get; set; }
    public string Email {get; set; } = null!;
    public string Name {get; set; } = null!;
    public string LastName {get; set; } = null!;
    public string Description {get; set; } = null!;
    public long PhoneNumber {get; set; }
    public string ProfilePhotoUrl {get; set; } = null!;
    public byte Genderu {get; set; }
}