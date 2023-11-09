
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;

namespace StudentHive.Infrastructure.Repositories;

public class PublicacionesRepository
{
    private readonly StudentHiveDbContext _context;

    public PublicacionesRepository (StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Publicacion>> GetAll ()
    {
        var publicaciones = await _context.Publicaciones
        .Include(anfi => anfi.IdAnfitrionNavigation)
        .ToListAsync();

        return publicaciones;
    }
    
}