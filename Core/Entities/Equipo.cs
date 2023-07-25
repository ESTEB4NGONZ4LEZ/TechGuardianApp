
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Equipo
{
    // * Atributos
    [Key]
    public int Id_equipo { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<EquipoComponente>? EquipoComponentes { get; set; }
    public ICollection<EquipoLugar>? EquipoLugares { get; set; }
}
