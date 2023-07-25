
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CategoriaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<CategoriaDto>> Get()
     {
          var categorias = await unitOfWork.Categoria.GetAllAsync();
          return this.mapper.Map<List<CategoriaDto>>(categorias);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<CategoriaDto>> Get(int id)
     {
          var categoria = await unitOfWork.Categoria.GetByIdAsync(id);
          if (categoria == null) {
               return NotFound();
          }
          return this.mapper.Map<CategoriaDto>(categoria);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<CategoriaDto>> Post(Categoria categoria)
     {
          this.unitOfWork.Categoria.Add(categoria);
          await unitOfWork.SaveAsync();
          if (categoria == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = categoria.Id_categoria}, categoria);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Put(string id, [FromBody]Categoria categoria)
    {
        if (categoria == null) {
            return NotFound();
        }
        unitOfWork.Categoria.Update(categoria);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<CategoriaDto>(categoria);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var categoria = await unitOfWork.Categoria.GetByIdAsync(id);
        if (categoria == null) {
            return NotFound();
        }
        unitOfWork.Categoria.Remove(categoria);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}