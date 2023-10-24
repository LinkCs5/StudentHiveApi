using AutoMapper;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
namespace StudentHive.Services.MappingsM;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Reserva, ReservaDTO>()
        .ForMember(dest => dest.IdReservas, opt=> opt.MapFrom(src => src.IdReservas))
        .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.IdPublicacionNavigation.Titulo))
        .ForMember(dest => dest.Imagenes, opt => opt.MapFrom(src => src.IdPublicacionNavigation.Imagenes))
        .ForMember(dest => dest.CantidadDeReservas, opt => opt.MapFrom(src => src.CantidadDeReservas))
        .ForMember(dest => dest.NumeroDeCuartos, opt => opt.MapFrom(src => src.IdHabitacionNavigation.NumeroDeCuartos))
        .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.IdHabitacionNavigation.Precio))
        .ForMember(dest => dest.Ubicacion, opt => opt.MapFrom( src => src.IdHabitacionNavigation.Ubicacion))
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.IdUsuarioNavigation.Nombre))
        .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => src.IdUsuarioNavigation.Edad))
        .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.IdUsuarioNavigation.Correo))
        .AfterMap((src, dest) => {
           if(src.IdPublicacionNavigation != null)
           {
                dest.Titulo = src.IdPublicacionNavigation.Titulo;
           }
        });
    }
    
}