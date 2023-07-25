
namespace API.Dtos;

public class AreaDto
{
    public int Id_area { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public List<LugarDto>? Lugares { get; set; }
}
