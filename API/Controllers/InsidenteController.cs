
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class InsidenteController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public InsidenteController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<InsidenteDto>> Get()
     {
          var insidentes = await unitOfWork.Insidente.GetAllAsync();
          return this.mapper.Map<List<InsidenteDto>>(insidentes);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<InsidenteDto>> Get(int id)
     {
          var insidente = await unitOfWork.Insidente.GetByIdAsync(id);
          if (insidente == null) {
               return NotFound();
          }
          return this.mapper.Map<InsidenteDto>(insidente);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<InsidenteDto>> Post(Insidente insidente)
     {
          this.unitOfWork.Insidente.Add(insidente);
          await unitOfWork.SaveAsync();
          if (insidente == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = insidente.Id_insidente}, insidente);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InsidenteDto>> Put(string id, [FromBody]Insidente insidente)
    {
        if (insidente == null) {
            return NotFound();
        }
        unitOfWork.Insidente.Update(insidente);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<InsidenteDto>(insidente);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var insidente = await unitOfWork.Insidente.GetByIdAsync(id);
        if (insidente == null) {
            return NotFound();
        }
        unitOfWork.Insidente.Remove(insidente);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}