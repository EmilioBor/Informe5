using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonoEstadoController : ControllerBase
    {
        private readonly IBonoEstadoService _service;

        public BonoEstadoController(IBonoEstadoService bonoEstado)
        {
            _service = bonoEstado;
        }


        [HttpGet]
        public async Task<IEnumerable<BonoEstadoDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BonoEstadoDtoOut>> GetById(int id)
        {
            var bonoEstado = await _service.GetDtoById(id);

            if (bonoEstado is null)
                return BonoEstadoNotFound(id);

            return bonoEstado;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(BonoEstadoDtoIn bonoEstado)
        {
            var newBonoEstado = await _service.Create(bonoEstado);


            return CreatedAtAction(nameof(GetById), new { id = newBonoEstado.Id }, newBonoEstado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BonoEstadoDtoIn bonoEstado)
        {
            if (id != bonoEstado.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({bonoEstado.Id}) del cuerpo de la solicitud." });

            var bonoEstadoToUpdate = await _service.GetById(id);

            if (bonoEstadoToUpdate is not null)
            {
                await _service.Update(id, bonoEstado);
                return NoContent();

            }
            else
            {
                return BonoEstadoNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var bonoEstadoToDelete = await _service.GetById(id);

            if (bonoEstadoToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return BonoEstadoNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult BonoEstadoNotFound(int id)
        {
            return NotFound(new { message = $"El bonoEstado con ID = {id} no existe." });
        }
    }
}
