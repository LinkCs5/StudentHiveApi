using AutoMapper;
using Microsoft.Data.SqlClient;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
namespace StudentHive.Services.MappingsM;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Reserva, ReservaDTO>()
        .ForMember(dest => dest.IdReservas, opt=> opt.MapFrom(src => src.IdReservas))
        .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
        .ForMember(dest => dest.IdHabitacion, opt => opt.MapFrom(src => src.IdHabitacion))
        .ForMember(dest => dest.IdPublicacion,opt => opt.MapFrom(src => src.IdPublicacion))
        .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.IdPublicacionNavigation.Titulo))
        .ForMember(dest => dest.CantidadDeReservas, opt => opt.MapFrom(src => src.CantidadDeReservas))
        .ForMember(dest => dest.NumeroDeCuartos, opt => opt.MapFrom(src => src.IdHabitacionNavigation.NumeroDeCuartos))
        .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.IdHabitacionNavigation.Precio))
        .AfterMap((src, dest) => {
           if(src.IdPublicacionNavigation != null)
           {
                dest.Titulo = src.IdPublicacionNavigation.Titulo;
           }
        });
        CreateMap<Publicacion, PublicacionesDTO>()
        .ForMember(dest => dest.PublicacionDate, opt => opt.MapFrom( src => src.FechaPublicacion))
        .ForMember(dest => dest.NumeroDeCuartos, opt => opt.MapFrom(src => src.IdHabitacionNavigation.NumeroDeCuartos))
        .ForMember(dest => dest.Ubicacion, opt => opt.MapFrom(src => src.IdHabitacionNavigation.Ubicacion))
        .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.IdHabitacionNavigation.Precio));

    }
    
}