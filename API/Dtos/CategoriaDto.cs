
namespace API.Dtos;

public class CategoriaDto
{
    public int Id_categoria { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public List<InsidenteDto>? Insidentes { get; set; }
}
