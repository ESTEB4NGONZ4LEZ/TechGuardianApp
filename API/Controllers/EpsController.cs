
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EpsController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public EpsController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<EpsDto>> Get()
     {
          var epss = await unitOfWork.Eps.GetAllAsync();
          return this.mapper.Map<List<EpsDto>>(epss);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EpsDto>> Get(int id)
     {
          var eps = await unitOfWork.Eps.GetByIdAsync(id);
          if (eps == null) {
               return NotFound();
          }
          return this.mapper.Map<EpsDto>(eps);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EpsDto>> Post(Eps eps)
     {
          this.unitOfWork.Eps.Add(eps);
          await unitOfWork.SaveAsync();
          if (eps == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = eps.Id_arl}, eps);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EpsDto>> Put(string id, [FromBody]Eps eps)
    {
        if (eps == null) {
            return NotFound();
        }
        unitOfWork.Eps.Update(eps);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<EpsDto>(eps);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var eps = await unitOfWork.Eps.GetByIdAsync(id);
        if (eps == null) {
            return NotFound();
        }
        unitOfWork.Eps.Remove(eps);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}