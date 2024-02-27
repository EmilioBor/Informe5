using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService paciente)
        {
            _service = paciente;
        }


        [HttpGet]
        public async Task<IEnumerable<PacienteDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDtoOut>> GetById(int id)
        {
            var paciente = await _service.GetDtoById(id);

            if (paciente is null)
                return PacienteNotFound(id);

            return paciente;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(PacienteDtoIn paciente)
        {
            var newPaciente = await _service.Create(paciente);


            return CreatedAtAction(nameof(GetById), new { id = newPaciente.Id }, newPaciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PacienteDtoIn paciente)
        {
            if (id != paciente.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({paciente.Id}) del cuerpo de la solicitud." });

            var pacienteToUpdate = await _service.GetById(id);

            if (pacienteToUpdate is not null)
            {
                await _service.Update(id, paciente);
                return NoContent();

            }
            else
            {
                return PacienteNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var pacienteToDelete = await _service.GetById(id);

            if (pacienteToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return PacienteNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult PacienteNotFound(int id)
        {
            return NotFound(new { message = $"El paciente con ID = {id} no existe." });
        }
    }
}
