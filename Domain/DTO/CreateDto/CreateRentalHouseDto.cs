using StudentHive.Domain.DTO.CreateDto.CreateResponseRentalHouseDto;

namespace StudentHive.Domain.DTO.Create;

public class CreateRentalHouseDto
{
    public int IdUser { get; set; }
    
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public string WhoElse { get; set; } = null!;

    public long RentPrice { get; set; }
    public IFormFile UrlImageHouse { get; set; } = null!;
    public virtual CreateHouseServiceDto? IdHouseServiceNavigation {get; set;} 
    public virtual CreateLocationDto? IdLocationNavigation {get; set;} 
    public virtual CreateRentalHouseDetailDto? IdRentalHouseDetailNavigation {get; set;}
    public virtual CreateTypeHouseRentalDto? IdTypeHouseRentalNavigation {get; set;} 

}