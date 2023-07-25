
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Componente
{
    // * Atrubutos
    [Key]
    public int id_componente { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<EquipoComponente>? EquipoComponentes { get; set; }
}
