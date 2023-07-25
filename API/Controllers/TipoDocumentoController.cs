
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoDocumentoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TipoDocumentoController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<TipoDocumentoDto>> Get()
     {
          var tipoDocumentos = await unitOfWork.TipoDocumento.GetAllAsync();
          return this.mapper.Map<List<TipoDocumentoDto>>(tipoDocumentos);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TipoDocumentoDto>> Get(int id)
     {
          var tipoDocumento = await unitOfWork.TipoDocumento.GetByIdAsync(id);
          if (tipoDocumento == null) {
               return NotFound();
          }
          return this.mapper.Map<TipoDocumentoDto>(tipoDocumento);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<TipoDocumentoDto>> Post(TipoDocumento tipoDocumento)
     {
          this.unitOfWork.TipoDocumento.Add(tipoDocumento);
          await unitOfWork.SaveAsync();
          if (tipoDocumento == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = tipoDocumento.Id_tipo_documento}, tipoDocumento);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumentoDto>> Put(string id, [FromBody]TipoDocumento tipoDocumento)
    {
        if (tipoDocumento == null) {
            return NotFound();
        }
        unitOfWork.TipoDocumento.Update(tipoDocumento);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<TipoDocumentoDto>(tipoDocumento);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var tipoDocumento = await unitOfWork.TipoDocumento.GetByIdAsync(id);
        if (tipoDocumento == null) {
            return NotFound();
        }
        unitOfWork.TipoDocumento.Remove(tipoDocumento);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}