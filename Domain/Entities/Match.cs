using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Match
{
    public int IdMatch { get; set; }

    public int? IdReserva { get; set; }

    public virtual Reservacion? IdReservaNavigation { get; set; }
}
