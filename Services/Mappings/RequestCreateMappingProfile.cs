using AutoMapper;
using StudentHive.Domain.DTO;
using StudentHive.Domain.DTO.Create;
using StudentHive.Domain.DTO.CreateDto.CreateResponseRentalHouseDto;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        // Mapping of User
        CreateMap<CreateUserDto, User>();

        // Mapping of RentalHouse
        CreateMap<RentalHouseDto, RentalHouse>();
        CreateMap<CreateHouseServiceDto, HouseService>();
        CreateMap<CreateLocationDto, Location>();
        CreateMap<CreateTypeHouseRentalDto, TypesHouseRental>();
        CreateMap<CreateRentalHouseDetailDto, RentalHouseDetail>();
        
    }
}