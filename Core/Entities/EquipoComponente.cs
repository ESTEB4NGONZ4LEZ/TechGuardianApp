
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class EquipoComponente
{
    // * Atributos
    [Key]
    public int Id_equipo_componente { get; set; }
    public int Id_equipo { get; set; }
    public int id_componente { get; set; }
    // * Referencia a la Enditad
    public Equipo? Equipo { get; set; }
    public Componente ? Componente { get; set; }
}
