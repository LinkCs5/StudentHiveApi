namespace StudentHive.Domain.DTO.Publitation;

public class PublicationUsersDto
{
    public int IdUser { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public virtual List<PublicationRentalHouseDto> RentalHouses { get; set; } = new ();
}