using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
namespace StudentHive.Services.Features.Publicaciones;


public class PublicacionesService
{
    private readonly PublicacionesRepository _publicacionesRepository;

    public PublicacionesService(PublicacionesRepository publicacionesRepository)
    {
        this._publicacionesRepository = publicacionesRepository;
    }

    public async Task<IEnumerable<Publicacion>> GetAll()
    {
        return await _publicacionesRepository.GetAll();
    }

    public async Task<Publicacion> GetById(int id)
    {
        return await _publicacionesRepository.GetById(id);
    }

    public async Task Add (Publicacion publicacion)
    {
        await _publicacionesRepository.Add (publicacion);
    }
}