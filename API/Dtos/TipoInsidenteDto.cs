
namespace API.Dtos;

public class TipoInsidenteDto
{
    public int Id_tipo_insidente { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public List<InsidenteDto>? Insidentes { get; set; }
}
