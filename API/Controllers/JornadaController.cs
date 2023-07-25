
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class JornadaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public JornadaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<JornadaDto>> Get()
     {
          var jornadas = await unitOfWork.Jornada.GetAllAsync();
          return this.mapper.Map<List<JornadaDto>>(jornadas);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<JornadaDto>> Get(int id)
     {
          var jornada = await unitOfWork.Jornada.GetByIdAsync(id);
          if (jornada == null) {
               return NotFound();
          }
          return this.mapper.Map<JornadaDto>(jornada);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<JornadaDto>> Post(Jornada jornada)
     {
          this.unitOfWork.Jornada.Add(jornada);
          await unitOfWork.SaveAsync();
          if (jornada == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = jornada.Id_jornada}, jornada);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<JornadaDto>> Put(string id, [FromBody]Jornada jornada)
    {
        if (jornada == null) {
            return NotFound();
        }
        unitOfWork.Jornada.Update(jornada);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<JornadaDto>(jornada);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var jornada = await unitOfWork.Jornada.GetByIdAsync(id);
        if (jornada == null) {
            return NotFound();
        }
        unitOfWork.Jornada.Remove(jornada);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}