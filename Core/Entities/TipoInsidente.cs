
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class TipoInsidente
{
    // * Atributos
    [Key]
    public int Id_tipo_insidente { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Insidente>? Insidentes { get; set; }
}
