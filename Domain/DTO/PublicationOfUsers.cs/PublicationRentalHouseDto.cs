namespace StudentHive.Domain.DTO.Publitation;

public class PublicationRentalHouseDto
{

    public int IdPublication { get; set; } 
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
    public string WhoElse { get; set; } = null!;
    public long RentPrice { get; set; }
    public DateTime PublicationDate { get; set; }

}