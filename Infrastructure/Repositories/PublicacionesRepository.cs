using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;

namespace StudentHive.Infrastructure.Repositories;

public class PublicacionesRepository
{
    private readonly StudentHiveDbContext _context;

    public PublicacionesRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task <IEnumerable<Publicacion>> GetAll()
    {
        var publicaciones  = await _context.Publicaciones
        .Include(publicacion => publicacion.IdHabitacionNavigation)
        .ToListAsync();
        return publicaciones;
    }

    public async Task <Publicacion> GetById(int id)
    {
        var publicacion = await _context.Publicaciones
        .FirstOrDefaultAsync(publicacion => publicacion.IdPublicacion == id );

        return publicacion ?? new Publicacion();
    }

    public async Task Add(Publicacion publicacion)
    {
        await _context.AddAsync(publicacion);
        await _context.SaveChangesAsync();
    }

}
