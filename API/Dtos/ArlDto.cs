
namespace API.Dtos;

public class ArlDto
{
    public int Id_arl { get; set; }
    public string? Nombre { get; set; }
    // * ICollection
    public List<TrainerDto>? Trainers { get; set; }
}
