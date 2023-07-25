
namespace API.Dtos;

public class TipoDocumentoDto
{
    public int Id_tipo_documento { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public List<PersonaDto>? Personas { get; set; }
}
