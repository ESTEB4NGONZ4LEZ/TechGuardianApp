
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Persona
{
    // * Atributos
    [Key]
    public int Id_persona { get; set; }
    public int Id_tipo_documento { get; set; }
    public string? Numero_documento { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int Id_salon { get; set; }
    public int Id_jornada { get; set; }
    // * ICollection
    public ICollection<Insidente>? Insidentes { get; set; }
    public ICollection<TrainerPersona>? TrainerPersonas { get; set;}
    public ICollection<CamperPersona>? CamperPersonas { get; set; }
    // * Referencia a la Entidad
    public TipoDocumento? TipoDocumento { get; set; }    
    public Salon? Salon { get; set; }
    public Jornada? Jornada { get; set; }
}
