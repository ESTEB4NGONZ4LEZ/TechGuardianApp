
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Camper
{
    // * Atributos
    [Key]
    public int Id_camper { get; set; }
    public int Id_eps { get; set; }
    // * ICollection
    public ICollection<CamperPersona>? CamperPersonas { get; set; }
    // * Referencia a la Entidad
    public Eps? Eps { get; set; }
}
