
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class CamperPersona
{
    // * Atributos
    [Key]
    public int Id_camper_persona { get; set; }
    public int Id_camper { get; set; }
    public int Id_persona { get; set; }
    // * Referencia a las entidades
    public Camper? Camper { get; set; }
    public Persona? Persona { get; set; }
}