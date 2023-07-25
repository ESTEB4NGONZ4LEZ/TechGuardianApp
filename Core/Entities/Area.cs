
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Area
{
    // * Atributos
    [Key]
    public int Id_area { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Lugar>? Lugares { get; set; }
    public ICollection<Insidente>? Insidentes { get; set; }
}
