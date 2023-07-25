
namespace API.Dtos;

public class SalonDto
{
    public int Id_salon { get; set; }
    public string? Nombre { get; set; }
    public List<PersonaDto>? Personas { get; set; }
}
