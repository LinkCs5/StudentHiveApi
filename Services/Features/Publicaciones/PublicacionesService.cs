
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Publicaciones;

public class PublicacionesService
{
    private readonly PublicacionesRepository _publicacionesRepository;

    public PublicacionesService ( PublicacionesRepository publicacionesRepository)
    {
        this._publicacionesRepository = publicacionesRepository;
    }

    public async Task <IEnumerable<Publicacion>> GetAll()
    {
        return await _publicacionesRepository.GetAll();
    }
}