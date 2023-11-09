

using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.Publicaciones;

namespace StudentHive.Services.Features.Reservaciones;

public class ReservacionesService
{
    private readonly ReservacionesRepository _reservacionesRepository;

    public ReservacionesService ( ReservacionesRepository reservacionesRepository)
    {
        this._reservacionesRepository = reservacionesRepository;
    }

    public async Task<IEnumerable<Reservacion>> GetAll()
    {
         return await _reservacionesRepository.GetAll();
    }

    public async Task<List<Reservacion>> GetReservacionesByInquilino(int id)
    {
        return await _reservacionesRepository.GetReservacionesByInquilino(id);
    }

        public async Task<Reservacion> GetById(int id)
    {
        return await _reservacionesRepository.GetById(id);
    }

    public async Task Add(Reservacion reservacion)
    {
        await  _reservacionesRepository.Add(reservacion);
    }
}