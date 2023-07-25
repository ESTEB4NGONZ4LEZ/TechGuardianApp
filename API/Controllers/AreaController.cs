
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AreaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public AreaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<AreaDto>> Get()
     {
          var areas = await unitOfWork.Areas.GetAllAsync();
          return this.mapper.Map<List<AreaDto>>(areas);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<AreaDto>> Get(int id)
     {
          var area = await unitOfWork.Areas.GetByIdAsync(id);
          if (area == null) {
               return NotFound();
          }
          return this.mapper.Map<AreaDto>(area);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<AreaDto>> Post(Area area)
     {
          this.unitOfWork.Areas.Add(area);
          await unitOfWork.SaveAsync();
          if (area == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = area.Id_area}, area);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Put(string id, [FromBody]Area area)
    {
        if (area == null) {
            return NotFound();
        }
        unitOfWork.Areas.Update(area);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<AreaDto>(area);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var area = await unitOfWork.Areas.GetByIdAsync(id);
        if (area == null) {
            return NotFound();
        }
        unitOfWork.Areas.Remove(area);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
