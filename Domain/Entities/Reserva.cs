using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Reserva
{
    public int IdReservas { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdPublicacion { get; set; }

    public int? CantidadDeReservas { get; set; }

    public int? IdHabitacion { get; set; }
    public virtual Habitacion? IdHabitacionNavigation { get; set; }

    public virtual Publicacion? IdPublicacionNavigation { get; set; } 

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
