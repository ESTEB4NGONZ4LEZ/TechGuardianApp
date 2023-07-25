
namespace API.Dtos;

public class PersonaDto
{
    public int Id_persona { get; set; }
    public int Id_tipo_documento { get; set; }
    public string? Numero_documento { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int Id_salon { get; set; }
    public int Id_jornada { get; set; }
    // * ICollection
    public List<InsidenteDto>? Insidentes { get; set; }
    public List<TrainerPersonaDto>? TrainerPersonas { get; set;}
    public List<CamperPersonaDto>? CamperPersonas { get; set; }
}
