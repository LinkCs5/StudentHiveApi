using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Reservas;

public class ReservacionesService
{
    private readonly ReservaRepository _reservaRepository;

    public ReservacionesService(ReservaRepository reservaRepository)
    {
        this._reservaRepository = reservaRepository;
    }

     public async Task<IEnumerable<Reserva>> GetAll()
     {
         return await _reservaRepository.GetAll();
     }

    public async Task<Reserva> GetById(int id)
    {
        return await _reservaRepository.GetById(id);
    }

    public async Task Add(Reserva reserva)
    {
        await _reservaRepository.Add(reserva);
    }

    // public async Task Delete (int id )
    // {
    //     var reserva = GetById(id);

    //     if(reserva.Id > 0)
    //         await _reservaRepository.Delete(id);
    // }
}