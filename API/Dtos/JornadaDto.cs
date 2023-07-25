
namespace API.Dtos;

public class JornadaDto
{
    public int Id_jornada { get; set; }
    public string? Nombre { get; set; }
    public List<PersonaDto>? Personas { get; set; }
}
