
namespace StudentHive.Domain.DTO;

public class ResevacionesDTO
{
    public int IdReserva { get; set; }

    public int? IdInquilino { get; set; }

    public int? IdPublicacion { get; set; }

    public string NombreInquilino {get; set;} = null!;

    public int Edad {get; set;}
    public string? Genero { get; set; }
    public string? NumeroTelefono { get; set; }

}