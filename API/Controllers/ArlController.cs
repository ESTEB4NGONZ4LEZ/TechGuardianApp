
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ArlController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ArlController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<ArlDto>> Get()
     {
          var arls = await unitOfWork.Areas.GetAllAsync();
          return this.mapper.Map<List<ArlDto>>(arls);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<ArlDto>> Get(int id)
     {
          var arl = await unitOfWork.Arl.GetByIdAsync(id);
          if (arl == null) {
               return NotFound();
          }
          return this.mapper.Map<ArlDto>(arl);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<ArlDto>> Post(Arl arl)
     {
          this.unitOfWork.Arl.Add(arl);
          await unitOfWork.SaveAsync();
          if (arl == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = arl.Id_arl}, arl);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ArlDto>> Put(string id, [FromBody]Arl arl)
    {
        if (arl == null) {
            return NotFound();
        }
        unitOfWork.Arl.Update(arl);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<ArlDto>(arl);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var arl = await unitOfWork.Arl.GetByIdAsync(id);
        if (arl == null) {
            return NotFound();
        }
        unitOfWork.Arl.Remove(arl);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}