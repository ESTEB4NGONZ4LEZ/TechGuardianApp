
namespace API.Dtos;

public class EquipoDto
{
    public int Id_equipo { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public List<EquipoComponenteDto>? EquipoComponentes { get; set; }
    public List<EquipoLugarDto>? EquipoLugares { get; set; }
}
