
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Eps
{
    // * Atributos
    [Key]
    public int Id_arl { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Camper>? Campers { get; set; }
}
