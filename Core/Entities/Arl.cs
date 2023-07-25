
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Arl
{
    // * Atributos
    [Key]
    public int Id_arl { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public ICollection<Trainer>? Trainers { get; set; }
}