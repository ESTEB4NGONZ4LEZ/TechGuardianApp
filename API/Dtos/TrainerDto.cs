
namespace API.Dtos;

public class TrainerDto
{
    public int Id_trainer { get; set; }
    public int Id_arl { get; set; }
    public List<TrainerPersonaDto>? TrainerPersonas { get; set; }
}
