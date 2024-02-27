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
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadService _service;

        public LocalidadController(ILocalidadService localidad)
        {
            _service = localidad;
        }


        [HttpGet]
        public async Task<IEnumerable<LocalidadDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LocalidadDtoOut>> GetById(int id)
        {
            var localidad = await _service.GetDtoById(id);

            if (localidad is null)
                return LocalidadNotFound(id);

            return localidad;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(LocalidadDtoIn localidad)
        {
            var newLocalidad = await _service.Create(localidad);


            return CreatedAtAction(nameof(GetById), new { id = newLocalidad.Id }, newLocalidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LocalidadDtoIn localidad)
        {
            if (id != localidad.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({localidad.Id}) del cuerpo de la solicitud." });

            var localidadToUpdate = await _service.GetById(id);

            if (localidadToUpdate is not null)
            {
                await _service.Update(id, localidad);
                return NoContent();

            }
            else
            {
                return LocalidadNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var localidadToDelete = await _service.GetById(id);

            if (localidadToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return LocalidadNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult LocalidadNotFound(int id)
        {
            return NotFound(new { message = $"El localidad con ID = {id} no existe." });
        }
    }
}
