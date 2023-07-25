
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EquipoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public EquipoController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<EquipoDto>> Get()
     {
          var equipos = await unitOfWork.Equipo.GetAllAsync();
          return this.mapper.Map<List<EquipoDto>>(equipos);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EquipoDto>> Get(int id)
     {
          var equipo = await unitOfWork.Equipo.GetByIdAsync(id);
          if (equipo == null) {
               return NotFound();
          }
          return this.mapper.Map<EquipoDto>(equipo);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EquipoDto>> Post(Equipo equipo)
     {
          this.unitOfWork.Equipo.Add(equipo);
          await unitOfWork.SaveAsync();
          if (equipo == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = equipo.Id_equipo}, equipo);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EquipoDto>> Put(string id, [FromBody]Equipo equipo)
    {
        if (equipo == null) {
            return NotFound();
        }
        unitOfWork.Equipo.Update(equipo);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<EquipoDto>(equipo);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var equipo = await unitOfWork.Equipo.GetByIdAsync(id);
        if (equipo == null) {
            return NotFound();
        }
        unitOfWork.Equipo.Remove(equipo);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}