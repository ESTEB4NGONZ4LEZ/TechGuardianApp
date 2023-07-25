
namespace API.Dtos;

public class InsidenteDto
{
    public int Id_insidente { get; set; }
    public int Id_persona { get; set; }
    public int Id_categoria { get; set; }
    public int Id_tipo_insidencia { get; set; }
    public int Id_area { get; set; }
    public string? Descripcion { get; set; }
    public DateTime Fecha { get; set; }
}
