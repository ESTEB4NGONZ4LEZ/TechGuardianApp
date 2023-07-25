
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EquipoComponenteController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public EquipoComponenteController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<EquipoComponenteDto>> Get()
     {
          var equipoComponentes = await unitOfWork.EquipoComponente.GetAllAsync();
          return this.mapper.Map<List<EquipoComponenteDto>>(equipoComponentes);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EquipoComponenteDto>> Get(int id)
     {
          var equipoComponente = await unitOfWork.EquipoComponente.GetByIdAsync(id);
          if (equipoComponente == null) {
               return NotFound();
          }
          return this.mapper.Map<EquipoComponenteDto>(equipoComponente);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EquipoComponenteDto>> Post(EquipoComponente equipoComponente)
     {
          this.unitOfWork.EquipoComponente.Add(equipoComponente);
          await unitOfWork.SaveAsync();
          if (equipoComponente == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = equipoComponente.Id_equipo_componente}, equipoComponente);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EquipoComponenteDto>> Put(string id, [FromBody]EquipoComponente equipoComponente)
    {
        if (equipoComponente == null) {
            return NotFound();
        }
        unitOfWork.EquipoComponente.Update(equipoComponente);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<EquipoComponenteDto>(equipoComponente);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var equipoComponente = await unitOfWork.EquipoComponente.GetByIdAsync(id);
        if (equipoComponente == null) {
            return NotFound();
        }
        unitOfWork.EquipoComponente.Remove(equipoComponente);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}