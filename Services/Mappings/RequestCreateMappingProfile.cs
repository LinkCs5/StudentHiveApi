using AutoMapper;
using Domain.DTO;
using StudentHive.Domain.DtoCreate;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<CreateUser, User>();

    }
}