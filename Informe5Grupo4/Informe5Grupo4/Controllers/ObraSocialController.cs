using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObraSocialController : ControllerBase
    {
        private readonly IObraSocialService _service;

        public ObraSocialController(IObraSocialService obraSocial)
        {
            _service = obraSocial;
        }


        [HttpGet]
        public async Task<IEnumerable<ObraSocialDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ObraSocialDtoOut>> GetById(int id)
        {
            var obraSocial = await _service.GetDtoById(id);

            if (obraSocial is null)
                return ObraSocialNotFound(id);

            return obraSocial;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(ObraSocialDtoIn obraSocial)
        {
            var newObraSocial = await _service.Create(obraSocial);


            return CreatedAtAction(nameof(GetById), new { id = newObraSocial.Id }, newObraSocial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ObraSocialDtoIn obraSocial)
        {
            if (id != obraSocial.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({obraSocial.Id}) del cuerpo de la solicitud." });

            var obraSocialToUpdate = await _service.GetById(id);

            if (obraSocialToUpdate is not null)
            {
                await _service.Update(id, obraSocial);
                return NoContent();

            }
            else
            {
                return ObraSocialNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var obraSocialToDelete = await _service.GetById(id);

            if (obraSocialToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return ObraSocialNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult ObraSocialNotFound(int id)
        {
            return NotFound(new { message = $"El obraSocial con ID = {id} no existe." });
        }
    }
}
