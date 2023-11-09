﻿using System;
using System.Collections.Generic;

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

    public string? Estatus { get; set; }

    public int? IdAnfitrion { get; set; }

    public virtual Arrendador? IdAnfitrionNavigation { get; set; }

    public virtual ICollection<Reservacion> Reservaciones { get; set; } = new List<Reservacion>();
}
