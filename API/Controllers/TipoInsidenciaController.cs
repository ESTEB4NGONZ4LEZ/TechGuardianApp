
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoInsidenciaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TipoInsidenciaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<TipoInsidenteDto>> Get()
     {
          var tipoInsidencias = await unitOfWork.TipoInsidente.GetAllAsync();
          return this.mapper.Map<List<TipoInsidenteDto>>(tipoInsidencias);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TipoInsidenteDto>> Get(int id)
     {
          var tipoInsidencia = await unitOfWork.TipoInsidente.GetByIdAsync(id);
          if (tipoInsidencia == null) {
               return NotFound();
          }
          return this.mapper.Map<TipoInsidenteDto>(tipoInsidencia);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TipoInsidenteDto>> Post(TipoInsidente tipoInsidente)
     {
          this.unitOfWork.TipoInsidente.Add(tipoInsidente);
          await unitOfWork.SaveAsync();
          if (tipoInsidente == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = tipoInsidente.Id_tipo_insidente}, tipoInsidente);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoInsidenteDto>> Put(string id, [FromBody]TipoInsidente tipoInsidente)
    {
        if (tipoInsidente == null) {
            return NotFound();
        }
        unitOfWork.TipoInsidente.Update(tipoInsidente);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TipoInsidenteDto>(tipoInsidente);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var tipoInsidente = await unitOfWork.TipoInsidente.GetByIdAsync(id);
        if (tipoInsidente == null) {
            return NotFound();
        }
        unitOfWork.TipoInsidente.Remove(tipoInsidente);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}