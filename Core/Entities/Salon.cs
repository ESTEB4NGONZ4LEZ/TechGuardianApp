
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Salon
{
    // * Atributos
    [Key]
    public int Id_salon { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Persona>? Personas { get; set; }
}
