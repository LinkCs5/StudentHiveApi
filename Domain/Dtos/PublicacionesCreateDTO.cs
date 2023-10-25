namespace StudentHive.Domain.Dtos;
public class PublicacionesCreateDTO
{
    public string? Titulo { get; set; } = null!;

    public string? Imagenes { get; set; } = null!;

    public int? NumeroDeCuartosHabitacion { get; set; }

    public string? UbicacionHabitacion { get; set;} = null!;

    public decimal? PrecioHabitacion { get; set; }
}