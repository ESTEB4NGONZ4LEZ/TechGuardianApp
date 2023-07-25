
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ComponenteController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ComponenteController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<ComponenteDto>> Get()
     {
          var componentes = await unitOfWork.Componente.GetAllAsync();
          return this.mapper.Map<List<ComponenteDto>>(componentes);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<ComponenteDto>> Get(int id)
     {
          var componente = await unitOfWork.Componente.GetByIdAsync(id);
          if (componente == null) {
               return NotFound();
          }
          return this.mapper.Map<ComponenteDto>(componente);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<ComponenteDto>> Post(Componente componente)
     {
          this.unitOfWork.Componente.Add(componente);
          await unitOfWork.SaveAsync();
          if (componente == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = componente.id_componente}, componente);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ComponenteDto>> Put(string id, [FromBody]Componente componente)
    {
        if (componente == null) {
            return NotFound();
        }
        unitOfWork.Componente.Update(componente);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<ComponenteDto>(componente);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var componente = await unitOfWork.Componente.GetByIdAsync(id);
        if (componente == null) {
            return NotFound();
        }
        unitOfWork.Componente.Remove(componente);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}