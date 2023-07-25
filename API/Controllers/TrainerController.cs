
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TrainerController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TrainerController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<TrainerDto>> Get()
     {
          var trainers = await unitOfWork.Trainer.GetAllAsync();
          return this.mapper.Map<List<TrainerDto>>(trainers);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TrainerDto>> Get(int id)
     {
          var trainer = await unitOfWork.Trainer.GetByIdAsync(id);
          if (trainer == null) {
               return NotFound();
          }
          return this.mapper.Map<TrainerDto>(trainer);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TrainerDto>> Post(Trainer trainer)
     {
          this.unitOfWork.Trainer.Add(trainer);
          await unitOfWork.SaveAsync();
          if (trainer == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = trainer.Id_trainer}, trainer);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainerDto>> Put(string id, [FromBody]Trainer trainer)
    {
        if (trainer == null) {
            return NotFound();
        }
        unitOfWork.Trainer.Update(trainer);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TrainerDto>(trainer);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var trainer = await unitOfWork.Trainer.GetByIdAsync(id);
        if (trainer == null) {
            return NotFound();
        }
        unitOfWork.Trainer.Remove(trainer);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}