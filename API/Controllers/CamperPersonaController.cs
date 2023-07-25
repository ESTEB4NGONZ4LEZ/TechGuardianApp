
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CamperPersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CamperPersonaController(IUnitOfWork _unitOfWork, IMapper mapper){
        unitOfWork = _unitOfWork;
        this.mapper = mapper;

    }
    // * ----- GET -----
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<CamperPersonaDto>> Get()
     {
          var camperPersonas = await unitOfWork.CamperPersona.GetAllAsync();
          return this.mapper.Map<List<CamperPersonaDto>>(camperPersonas);
     }
    // * ----- GET ID -----
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<CamperPersonaDto>> Get(int id)
     {
          var camperPersona = await unitOfWork.CamperPersona.GetByIdAsync(id);
          if (camperPersona == null) {
               return NotFound();
          }
          return this.mapper.Map<CamperPersonaDto>(camperPersona);
     }
    // * ----- POST -----
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<CamperPersonaDto>> Post(CamperPersona camperPersona)
     {
          this.unitOfWork.CamperPersona.Add(camperPersona);
          await unitOfWork.SaveAsync();
          if (camperPersona == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = camperPersona.Id_camper_persona}, camperPersona);
     }
     // * ----- PUT -----
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CamperPersonaDto>> Put(string id, [FromBody]CamperPersona camperPersona)
    {
        if (camperPersona == null) {
            return NotFound();
        }
        unitOfWork.CamperPersona.Update(camperPersona);
        await unitOfWork.SaveAsync();
        return this.mapper.Map<CamperPersonaDto>(camperPersona);
    }
    // * ----- DELETE -----
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var camperPersona = await unitOfWork.CamperPersona.GetByIdAsync(id);
        if (camperPersona == null) {
            return NotFound();
        }
        unitOfWork.CamperPersona.Remove(camperPersona);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}