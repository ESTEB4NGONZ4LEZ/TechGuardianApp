
namespace API.Dtos;

public class ComponenteDto
{
    public int id_componente { get; set; }
    public string? Nombre { get; set; }
    public List<EquipoComponenteDto>? EquipoComponentes { get; set; }
}
