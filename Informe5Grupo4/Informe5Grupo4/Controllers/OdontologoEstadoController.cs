using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdontologoEstadoController : ControllerBase
    {
        private readonly IOdontologoEstadoService _service;

        public OdontologoEstadoController(IOdontologoEstadoService odontologoEstado)
        {
            _service = odontologoEstado;
        }


        [HttpGet]
        public async Task<IEnumerable<OdontologoEstadoDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OdontologoEstadoDtoOut>> GetById(int id)
        {
            var odontologoEstado = await _service.GetDtoById(id);

            if (odontologoEstado is null)
                return OdontologoEstadoNotFound(id);

            return odontologoEstado;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(OdontologoEstadoDtoIn odontologoEstado)
        {
            var newOdontologoEstado = await _service.Create(odontologoEstado);


            return CreatedAtAction(nameof(GetById), new { id = newOdontologoEstado.Id }, newOdontologoEstado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OdontologoEstadoDtoIn odontologoEstado)
        {
            if (id != odontologoEstado.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({odontologoEstado.Id}) del cuerpo de la solicitud." });

            var odontologoEstadoToUpdate = await _service.GetById(id);

            if (odontologoEstadoToUpdate is not null)
            {
                await _service.Update(id, odontologoEstado);
                return NoContent();

            }
            else
            {
                return OdontologoEstadoNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var odontologoEstadoToDelete = await _service.GetById(id);

            if (odontologoEstadoToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return OdontologoEstadoNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult OdontologoEstadoNotFound(int id)
        {
            return NotFound(new { message = $"El odontologoEstado con ID = {id} no existe." });
        }
    }
}
