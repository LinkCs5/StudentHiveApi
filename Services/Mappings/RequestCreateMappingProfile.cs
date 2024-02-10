using AutoMapper;
using StudentHive.Domain.DTO;
using StudentHive.Domain.DTO.Create;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<RentalHouseDto, RentalHouse>();
    }
}