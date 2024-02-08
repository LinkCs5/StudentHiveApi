namespace StudentHive.Domain.DtoUpdate;

public class UpdateRentalHouseDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
    public string WhoElse { get; set; } = null!;
    public long RentPrice { get; set; }
    public int? IdRentalHouseDetail { get; set; }
    public int? IdTypeHouseRental { get; set; }
    public int? IdLocation { get; set; }
    public int? IdHouseService { get; set; }    


}