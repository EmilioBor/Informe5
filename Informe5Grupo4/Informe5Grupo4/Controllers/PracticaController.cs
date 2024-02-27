using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticaController : ControllerBase
    {
        private readonly IPracticaService _service;

        public PracticaController(IPracticaService practica)
        {
            _service = practica;
        }


        [HttpGet]
        public async Task<IEnumerable<PracticaDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PracticaDtoOut>> GetById(int id)
        {
            var practica = await _service.GetDtoById(id);

            if (practica is null)
                return PracticaNotFound(id);

            return practica;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(PracticaDtoIn practica)
        {
            var newPractica = await _service.Create(practica);


            return CreatedAtAction(nameof(GetById), new { id = newPractica.Id }, newPractica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PracticaDtoIn practica)
        {
            if (id != practica.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({practica.Id}) del cuerpo de la solicitud." });

            var practicaToUpdate = await _service.GetById(id);

            if (practicaToUpdate is not null)
            {
                await _service.Update(id, practica);
                return NoContent();

            }
            else
            {
                return PracticaNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var practicaToDelete = await _service.GetById(id);

            if (practicaToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return PracticaNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult PracticaNotFound(int id)
        {
            return NotFound(new { message = $"El practica con ID = {id} no existe." });
        }
    }
}
