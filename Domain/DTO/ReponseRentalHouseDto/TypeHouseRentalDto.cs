namespace StudentHive.Domain.DTO.ReponseRentalHouseDto;

public class TypeHouseRentalDto
{
    public int IdTypeHouseRental { get; set; }
    public bool? OwnHouse { get; set; }
    public bool? SharedRoom { get; set; }
    public bool? SingleRoom { get; set; }
    public virtual RentalHouseDto? RentalHouses { get; set; }
}