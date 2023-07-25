
namespace API.Dtos;

public class EpsDto
{
    public int Id_arl { get; set; }
    public string? Nombre { get; set; }
    public List<CamperDto>? Campers { get; set; }
}
