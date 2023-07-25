

using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Jornada
{
    // * Atributos
    [Key]
    public int Id_jornada { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Persona>? Personas { get; set; }
}
