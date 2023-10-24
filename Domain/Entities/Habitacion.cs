using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentHive.Domain.Entities;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public int NumeroDeCuartos { get; set; }

    public decimal Precio { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public virtual ICollection<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
