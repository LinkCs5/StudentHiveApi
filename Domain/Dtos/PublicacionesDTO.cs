namespace StudentHive.Domain.Dtos;

public class PublicacionesDTO
{
    public int IdPublicacion { get; set; }

    public string? Titulo { get; set; } = null!;

    public string? Imagenes { get; set; } = null!;

    public int? NumeroDeCuartos { get; set; }

    public string? Ubicacion { get; set;} = null!;

    public decimal? Precio { get; set; }

    public DateTime? PublicacionDate { get; set; }
}