
namespace API.Dtos;

public class CamperDto
{
    public int Id_camper { get; set; }
    public int Id_eps { get; set; }
    // * ICollection
    public List<CamperPersonaDto>? CamperPersonas { get; set; }   
}
