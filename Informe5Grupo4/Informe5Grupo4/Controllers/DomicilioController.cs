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
    public class DomicilioController : ControllerBase
    {
        private readonly IDomicilioService _service;

        public DomicilioController(IDomicilioService domicilio)
        {
            _service = domicilio;
        }


        [HttpGet]
        public async Task<IEnumerable<DomicilioDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DomicilioDtoOut>> GetById(int id)
        {
            var domicilio = await _service.GetDtoById(id);

            if (domicilio is null)
                return DomicilioNotFound(id);

            return domicilio;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(DomicilioDtoIn domicilio)
        {
            var newDomicilio = await _service.Create(domicilio);


            return CreatedAtAction(nameof(GetById), new { id = newDomicilio.Id }, newDomicilio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DomicilioDtoIn domicilio)
        {
            if (id != domicilio.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({domicilio.Id}) del cuerpo de la solicitud." });

            var domicilioToUpdate = await _service.GetById(id);

            if (domicilioToUpdate is not null)
            {
                await _service.Update(id, domicilio);
                return NoContent();

            }
            else
            {
                return DomicilioNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var domicilioToDelete = await _service.GetById(id);

            if (domicilioToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return DomicilioNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult DomicilioNotFound(int id)
        {
            return NotFound(new { message = $"El domicilio con ID = {id} no existe." });
        }
    }
}
