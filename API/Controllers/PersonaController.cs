
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public PersonaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<PersonaDto>> Get()
     {
          var personas = await unitOfWork.Persona.GetAllAsync();
          return this.mapper.Map<List<PersonaDto>>(personas);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<PersonaDto>> Get(int id)
     {
          var persona = await unitOfWork.Persona.GetByIdAsync(id);
          if (persona == null) {
               return NotFound();
          }
          return this.mapper.Map<PersonaDto>(persona);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<PersonaDto>> Post(Persona persona)
     {
          this.unitOfWork.Persona.Add(persona);
          await unitOfWork.SaveAsync();
          if (persona == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = persona.Id_persona}, persona);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Put(string id, [FromBody]Persona persona)
    {
        if (persona == null) {
            return NotFound();
        }
        unitOfWork.Persona.Update(persona);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<PersonaDto>(persona);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var persona = await unitOfWork.Persona.GetByIdAsync(id);
        if (persona == null) {
            return NotFound();
        }
        unitOfWork.Persona.Remove(persona);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}