using AutoMapper;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<ReservaCreateDTO, Reserva>()
        .AfterMap
        (
            (src,dest) =>
            {
                
            }
        );
        
    }
}