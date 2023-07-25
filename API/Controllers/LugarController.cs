
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LugarController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public LugarController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<LugarDto>> Get()
     {
          var lugares = await unitOfWork.Lugar.GetAllAsync();
          return this.mapper.Map<List<LugarDto>>(lugares);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<LugarDto>> Get(int id)
     {
          var lugar = await unitOfWork.Lugar.GetByIdAsync(id);
          if (lugar == null) {
               return NotFound();
          }
          return this.mapper.Map<LugarDto>(lugar);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<LugarDto>> Post(Lugar lugar)
     {
          this.unitOfWork.Lugar.Add(lugar);
          await unitOfWork.SaveAsync();
          if (lugar == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = lugar.Id_lugar}, lugar);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LugarDto>> Put(string id, [FromBody]Lugar lugar)
    {
        if (lugar == null) {
            return NotFound();
        }
        unitOfWork.Lugar.Update(lugar);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<LugarDto>(lugar);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var lugar = await unitOfWork.Lugar.GetByIdAsync(id);
        if (lugar == null) {
            return NotFound();
        }
        unitOfWork.Lugar.Remove(lugar);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}