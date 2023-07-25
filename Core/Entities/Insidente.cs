
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Insidente
{
    // * Atributos
    [Key]
    public int Id_insidente { get; set; }
    public int Id_persona { get; set; }
    public int Id_categoria { get; set; }
    public int Id_tipo_insidencia { get; set; }
    public int Id_area { get; set; }
    public string? Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    // * Referencia a la Entidad
    public Persona? Persona { get; set; }
    public Categoria? Categoria { get; set; }
    public TipoInsidente? TipoInsidente { get; set; }
    public Area? Area { get; set; }
}
