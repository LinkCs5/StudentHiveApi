using AutoMapper;
using Microsoft.Data.SqlClient;
using StudentHive.Domain.DTO;
using StudentHive.Domain.Entities;
namespace StudentHive.Services.MappingsM;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Publicacion, PublicacionesDTO>();
        CreateMap<Reservacion, ResevacionesDTO>()
        .ForMember(dest => dest.NombreInquilino, opt => opt
        .MapFrom(src => src.IdInquilinoNavigation.NombreInquilino))
        .ForMember(dest => dest.Edad, opt => opt
        .MapFrom(src => src.IdInquilinoNavigation.Edad))        
        .ForMember(dest => dest.NumeroTelefono, opt => opt
        .MapFrom(src => src.IdInquilinoNavigation.NumeroTelefono))
        .ForMember(dest => dest.Genero, opt => opt.
        MapFrom(src => src.IdInquilinoNavigation.Genero));
        CreateMap<Match, MatchsDTO>();
    }
    
    
}