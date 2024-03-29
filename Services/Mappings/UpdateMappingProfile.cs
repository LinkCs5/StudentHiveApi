
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentHive.Domain.DtoUpdate;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class UpdateMappingProfile : Profile
{
    public UpdateMappingProfile()
    {
        CreateMap<UpdateUserDto, User>();
        CreateMap<UpdateRentalHouseDto, RentalHouse>();
    }
}