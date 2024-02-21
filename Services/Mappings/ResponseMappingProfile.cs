using AutoMapper;
using Microsoft.Data.SqlClient;
using StudentHive.Domain.DTO;
using StudentHive.Domain.DTO.Publitation;
using StudentHive.Domain.DTO.ReponseRentalHouseDto;
using StudentHive.Domain.Entities;
namespace StudentHive.Services.MappingsM;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        // Mapping for User
        CreateMap<User, UserDto>();

        // Mapping for Publication Users
        CreateMap<User, PublicationUsersDto>();
        CreateMap<RentalHouse, PublicationRentalHouseDto>()
        .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationDate.Date.Year));

        // Mapping for RentalHouse
        CreateMap<User,UserReponseDto>(); 
        CreateMap<HouseService, HouseServiceDto>(); 
        CreateMap<Location, LocationDto>();
        CreateMap<RentalHouseDetail, RentalHouseDetailDto>();
        CreateMap<TypesHouseRental, TypeHouseRentalDto>();
        CreateMap<RentalHouse, RentalHouseDto>()
        .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationDate.Date.Year));

    }   
}