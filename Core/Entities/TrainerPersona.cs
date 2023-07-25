
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class TrainerPersona
{
    // * Atributos
    [Key]
    public int Id_trainer_persona { get; set; }
    public int Id_trainer { get; set; }
    public int Id_persona { get; set; }
    // * Referencia a la clase
    public Trainer? Trainer { get; set; }
    public Persona? Persona { get; set; }
}
