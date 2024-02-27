using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdontologoController : ControllerBase
    {
        private readonly IOdontologoService _service;

        public OdontologoController(IOdontologoService odontologo)
        {
            _service = odontologo;
        }


        [HttpGet]
        public async Task<IEnumerable<OdontologoDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OdontologoDtoOut>> GetById(int id)
        {
            var odontologo = await _service.GetDtoById(id);

            if (odontologo is null)
                return OdontologoNotFound(id);

            return odontologo;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(OdontologoDtoIn odontologo)
        {
            var newOdontologo = await _service.Create(odontologo);


            return CreatedAtAction(nameof(GetById), new { id = newOdontologo.Id }, newOdontologo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OdontologoDtoIn odontologo)
        {
            if (id != odontologo.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({odontologo.Id}) del cuerpo de la solicitud." });

            var odontologoToUpdate = await _service.GetById(id);

            if (odontologoToUpdate is not null)
            {
                await _service.Update(id, odontologo);
                return NoContent();

            }
            else
            {
                return OdontologoNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var odontologoToDelete = await _service.GetById(id);

            if (odontologoToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return OdontologoNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult OdontologoNotFound(int id)
        {
            return NotFound(new { message = $"El odontologo con ID = {id} no existe." });
        }
    }
}
