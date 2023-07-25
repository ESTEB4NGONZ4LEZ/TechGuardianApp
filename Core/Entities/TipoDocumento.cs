
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class TipoDocumento
{
    // * Atributos
    [Key]
    public int Id_tipo_documento { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Persona>? Personas { get; set; }

}
