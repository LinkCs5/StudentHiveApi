namespace StudentHive.Domain.DTO;

public class RentalHouseDto
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public string WhoElse { get; set; } = null!;

    public long RentPrice { get; set; }

}