
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Categoria
{
    // * Atributos
    [Key]
    public int Id_categoria { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Insidente>? Insidentes { get; set; }
}
