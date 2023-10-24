using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace StudentHive.Domain.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Genero { get; set; }

    public string? NumeroTelefono { get; set; }

    public DateTime? FechaDeCreacion { get; set; }

    public int? Edad { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
