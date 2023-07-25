
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Lugar
{
    // * Atributos
    [Key]
    public int Id_lugar { get; set; }
    public string? Nombre { get; set; }
    public int Id_area { get; set; }
    // * ICollection
    public ICollection<EquipoLugar>? EquipoLugares { get; set; }
    // * Referencia a la Entidad
    public Area? Area { get; set; }

}
