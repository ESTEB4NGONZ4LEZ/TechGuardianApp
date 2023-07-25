
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SalonController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public SalonController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<SalonDto>> Get()
     {
          var salones = await unitOfWork.Salon.GetAllAsync();
          return this.mapper.Map<List<SalonDto>>(salones);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<SalonDto>> Get(int id)
     {
          var salon = await unitOfWork.Salon.GetByIdAsync(id);
          if (salon == null) {
               return NotFound();
          }
          return this.mapper.Map<SalonDto>(salon);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<SalonDto>> Post(Salon salon)
     {
          this.unitOfWork.Salon.Add(salon);
          await unitOfWork.SaveAsync();
          if (salon == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = salon.Id_salon}, salon);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SalonDto>> Put(string id, [FromBody]Salon salon)
    {
        if (salon == null) {
            return NotFound();
        }
        unitOfWork.Salon.Update(salon);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<SalonDto>(salon);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var salon = await unitOfWork.Salon.GetByIdAsync(id);
        if (salon == null) {
            return NotFound();
        }
        unitOfWork.Salon.Remove(salon);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}