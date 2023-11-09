
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class ReservacionesRepository
{
    private readonly StudentHiveDbContext _context;

    public ReservacionesRepository ( StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Reservacion>> GetAll()
    {
        var reservaciones = await _context.Reservaciones
        .Include(inquilno => inquilno.IdInquilinoNavigation)
        .ToListAsync();

        return reservaciones; 
    }

    public async Task<Reservacion> GetById (int id)
    {
        var reservaciones = await _context.Reservaciones.FirstOrDefaultAsync(reserva => reserva.IdInquilino == id);
        return reservaciones ?? new Reservacion();
    }

        public async Task<List<Reservacion>> GetReservacionesByInquilino (int id)
    {
        var reservaciones = await _context.Reservaciones
        .Where(reserva => reserva.IdInquilino == id).ToListAsync();

        return reservaciones;
    }

    public async Task Add (Reservacion reservacion)
    {
        await _context.AddAsync(reservacion);
        await _context.SaveChangesAsync();
    }
}