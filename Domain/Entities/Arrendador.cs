using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Arrendador
{
    public int IdAnfitrion { get; set; }

    public string? NombreAnfitrion { get; set; }

    public string? Genero { get; set; }

    public string? NumeroTelefono { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Publicacion> Publicaciones { get; set; } = new List<Publicacion>();
}
