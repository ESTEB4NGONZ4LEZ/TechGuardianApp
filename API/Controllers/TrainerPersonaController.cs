
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TrainerPersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TrainerPersonaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<TrainerPersonaDto>> Get()
     {
          var trainerPersonas = await unitOfWork.TrainerPersona.GetAllAsync();
          return this.mapper.Map<List<TrainerPersonaDto>>(trainerPersonas);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TrainerPersonaDto>> Get(int id)
     {
          var trainerPersona = await unitOfWork.TrainerPersona.GetByIdAsync(id);
          if (trainerPersona == null) {
               return NotFound();
          }
          return this.mapper.Map<TrainerPersonaDto>(trainerPersona);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TrainerPersonaDto>> Post(TrainerPersona trainerPersona)
     {
          this.unitOfWork.TrainerPersona.Add(trainerPersona);
          await unitOfWork.SaveAsync();
          if (trainerPersona == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = trainerPersona.Id_trainer_persona}, trainerPersona);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainerPersonaDto>> Put(string id, [FromBody]TrainerPersona trainerPersona)
    {
        if (trainerPersona == null) {
            return NotFound();
        }
        unitOfWork.TrainerPersona.Update(trainerPersona);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TrainerPersonaDto>(trainerPersona);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var trainerPersona = await unitOfWork.TrainerPersona.GetByIdAsync(id);
        if (trainerPersona == null) {
            return NotFound();
        }
        unitOfWork.TrainerPersona.Remove(trainerPersona);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}