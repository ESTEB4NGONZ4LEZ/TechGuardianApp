
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EquipoLugarController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public EquipoLugarController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<EquipoLugarDto>> Get()
     {
          var equipoLugares = await unitOfWork.EquipoLugar.GetAllAsync();
          return this.mapper.Map<List<EquipoLugarDto>>(equipoLugares);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EquipoLugarDto>> Get(int id)
     {
          var equipoLugar = await unitOfWork.EquipoLugar.GetByIdAsync(id);
          if (equipoLugar == null) {
               return NotFound();
          }
          return this.mapper.Map<EquipoLugarDto>(equipoLugar);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EquipoLugarDto>> Post(EquipoLugar equipoLugar)
     {
          this.unitOfWork.EquipoLugar.Add(equipoLugar);
          await unitOfWork.SaveAsync();
          if (equipoLugar == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = equipoLugar.Id_equipo_lugar}, equipoLugar);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EquipoLugarDto>> Put(string id, [FromBody]EquipoLugar equipoLugar)
    {
        if (equipoLugar == null) {
            return NotFound();
        }
        unitOfWork.EquipoLugar.Update(equipoLugar);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<EquipoLugarDto>(equipoLugar);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var equipoLugar = await unitOfWork.EquipoLugar.GetByIdAsync(id);
        if (equipoLugar == null) {
            return NotFound();
        }
        unitOfWork.EquipoLugar.Remove(equipoLugar);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}