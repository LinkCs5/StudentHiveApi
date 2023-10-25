namespace StudentHive.Domain.Dtos;

public class ReservaDTO
{
    public int IdReservas {get; set; }
    public int IdHabitacion {get; set;}
    public int IdUsuario {get; set;}
    public int IdPublicacion {get; set;}
    public string? Titulo { get; set; } = null!;
    public int? CantidadDeReservas { get; set; } = null!;
    public int NumeroDeCuartos { get; set; }
    public decimal Precio { get; set; } 
}