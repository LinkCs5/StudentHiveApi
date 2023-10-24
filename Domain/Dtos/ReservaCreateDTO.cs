

public class ReservaCreateDTO
{
    public string? Titulo { get; set; } = null!;
    public string? Imagenes { get; set; } = null!;
    public int? CantidadDeReservas { get; set; } = null!;
    public int NumeroDeCuartos { get; set; }
    public decimal Precio { get; set; } 
    public string? Ubicacion { get; set; } = null!;
    public string? Nombre { get; set; } = null!;
    public int? Edad { get; set; }
    public string? Correo { get; set; } = null!;

}