using AutoMapper;
using StudentHive.Domain.DTO;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {

        CreateMap<CreateReservacionesDTO, Reservacion>();
        CreateMap<CreateMatchsDTO,Match>();

    }
}