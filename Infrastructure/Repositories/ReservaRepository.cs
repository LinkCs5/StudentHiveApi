using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data;

namespace StudentHive.Infrastructure.Repositories;

public class ReservaRepository
{
    private readonly StudentHiveDbContext _context;

    public ReservaRepository (StudentHiveDbContext context)
    {
        this._context = context;
    }
    public async Task<IEnumerable<Reserva>> GetAll()
    {
        var reservas = await _context.Reservas
        .Include(reserva => reserva.IdHabitacionNavigation)
        .Include(reserva => reserva.IdPublicacionNavigation)
        .Include(reserva => reserva.IdUsuarioNavigation)
        .ToListAsync();
        return reservas;
    }

    public async Task <Reserva> GetById(int id)
    {
        var reserva = await _context.Reservas 
        .Include(reserva => reserva.IdHabitacionNavigation)
        .Include(reserva => reserva.IdPublicacionNavigation)
        .Include(reserva => reserva.IdUsuarioNavigation)
        .FirstOrDefaultAsync(reserva => reserva.IdReservas == id);
        
        return reserva ?? new Reserva();
    }
    public async Task Add(Reserva reserva)
    {
        await _context.AddAsync(reserva);
        await _context.SaveChangesAsync();
    }
        
}
