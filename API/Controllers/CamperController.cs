
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CamperController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CamperController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<CamperDto>> Get()
     {
          var campers = await unitOfWork.Camper.GetAllAsync();
          return this.mapper.Map<List<CamperDto>>(campers);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<CamperDto>> Get(int id)
     {
          var camper = await unitOfWork.Camper.GetByIdAsync(id);
          if (camper == null) {
               return NotFound();
          }
          return this.mapper.Map<CamperDto>(camper);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<CamperDto>> Post(Camper camper)
     {
          this.unitOfWork.Camper.Add(camper);
          await unitOfWork.SaveAsync();
          if (camper == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = camper.Id_camper}, camper);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CamperDto>> Put(string id, [FromBody]Camper camper)
    {
        if (camper == null) {
            return NotFound();
        }
        unitOfWork.Camper.Update(camper);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<CamperDto>(camper);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var camper = await unitOfWork.Camper.GetByIdAsync(id);
        if (camper == null) {
            return NotFound();
        }
        unitOfWork.Camper.Remove(camper);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}