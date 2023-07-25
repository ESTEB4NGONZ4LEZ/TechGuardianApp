
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Trainer
{
    // * Atributos
    [Key]
    public int Id_trainer { get; set; }
    public int Id_arl { get; set; }
    // * ICollection
    public ICollection<TrainerPersona>? TrainerPersonas { get; set; }
    // * Referencia a la Entidad
    public Arl? Arl { get; set; }
}
