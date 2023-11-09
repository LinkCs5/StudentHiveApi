using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Reservacion
{
    public int IdReserva { get; set; }

    public int? IdInquilino { get; set; }

    public int? IdPublicacion { get; set; }

    public int? CantidadDeReservas { get; set; }

    public virtual Inquilino? IdInquilinoNavigation { get; set; }

    public virtual Publicacion? IdPublicacionNavigation { get; set; }

    public virtual ICollection<Match> Matchs { get; set; } = new List<Match>();
}
