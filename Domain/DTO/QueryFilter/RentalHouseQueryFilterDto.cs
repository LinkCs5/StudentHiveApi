namespace StudentHive.Domain.DTO.QueryFilter;

public class RentalHouseQueryFilterDto
{
    public int IdRentalHouse { get; set; }
    public bool Status { get; set; }
    public string WhoElse { get; set; } = null!;
    public long RentPrice { get; set; }
    public DateTime PublicationDate { get; set; }
    public bool Wifi { get; set; }
    public bool Kitchen { get; set; }
    public bool Washer { get; set; }
    public bool AirConditioning { get; set; }
    public bool Water { get; set; }
    public bool Gas { get; set; }
    public bool Television { get; set; }
    public string Address{ get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int PostalCode { get; set; }
    public string? Neighborhood { get; set; }
    public int NumberOfGuests { get; set; }
    public int NumberOfBathrooms { get; set; }
    public int NumberOfRooms { get; set; }
    public int NumbersOfBed { get; set; }
    public int NumberOfHammocks { get; set; }
    public bool OwnHouse { get; set; }
    public bool SharedRoom { get; set; }
    public bool SingleRoom { get; set; }
   
}