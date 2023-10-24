using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace StudentHive.Domain.Entities;

public partial class Publicacion
{
    public int IdPublicacion { get; set; }

    public string? Titulo { get; set; } 

    public string? Imagenes { get; set; }

    public int? NumeroDeCuartosHabitacion { get; set; }

    public string? UbicacionHabitacion { get; set; }

    public decimal? PrecioHabitacion { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public int? IdHabitacion { get; set; }

    public virtual Habitacion? IdHabitacionNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
