
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class EquipoLugar
{
    // * Atributos
    [Key]
    public int Id_equipo_lugar { get; set; }
    public int Id_equipo { get; set; }
    public int Id_lugar { get; set; }
    // * Referencia a la Entidad 
    public Equipo? Equipo { get; set; }
    public Lugar? Lugar { get; set; }
}
