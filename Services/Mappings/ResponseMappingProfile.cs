using AutoMapper;
using Domain.DTO;
using Microsoft.Data.SqlClient;
using StudentHive.Domain.Entities;
namespace StudentHive.Services.MappingsM;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<User, UserDto>()
        .ForMember( dest => dest.UserAge, opt => opt.MapFrom(src => src.UserAge ?? 0));
    }
    
    
}