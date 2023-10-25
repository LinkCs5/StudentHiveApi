using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Services.Mappings;

public class RequestCreateMappingProfile : Profile
{
    Random random = new Random();
    public RequestCreateMappingProfile()
    {
        CreateMap<PublicacionesCreateDTO, Publicacion>()
        .AfterMap
        (
            (src,dest) =>
            {
                dest.FechaPublicacion = DateTime.Now;
            }
        );

        CreateMap<ReservaCreateDTO, Reserva>()
        .AfterMap
        (
            (src, dest) =>
            {
                dest.CantidadDeReservas = random.Next(10);
            }
        );


    }
}