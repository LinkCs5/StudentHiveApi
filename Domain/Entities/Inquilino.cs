using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Inquilino
{
    public int IdInquilino { get; set; }

    public string NombreInquilino { get; set; } = null!;

    public string? Genero { get; set; }

    public string? NumeroTelefono { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Reservacion> Reservaciones { get; set; } = new List<Reservacion>();
}
