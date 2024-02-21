using StudentHive.Domain.DTO.ReponseRentalHouseDto;
using StudentHive.Domain.Entities;

namespace StudentHive.Domain.DTO;

public class RentalHouseDto
{   
    public int IdPublication { get; set; } 
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public string WhoElse { get; set; } = null!;

    public long RentPrice { get; set; }
    
    public DateTime PublicationDate { get; set; }

    public IFormFile UrlImageHouse { get; set; } = null!;
    public virtual UserReponseDto? IdUserNavigation { get; set; }

    public virtual HouseServiceDto? IdHouseServiceNavigation {get; set;} 
    public virtual LocationDto? IdLocationNavigation {get; set;} 
    public virtual RentalHouseDetailDto? IdRentalHouseDetailNavigation {get; set;}
    public virtual TypeHouseRentalDto? IdTypeHouseRentalNavigation {get; set;} 

}