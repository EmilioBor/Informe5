using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonoController : ControllerBase
    {
        private readonly IBonoService _service;

        public BonoController(IBonoService bono)
        {
            _service = bono;

        }


        [HttpGet]
        public async Task<IEnumerable<BonoDtoOut>> Get()
        {
            return await _service.GetAll();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BonoDtoOut>> GetById(int id)
        {
            var bono = await _service.GetDtoById(id);

            if (bono is null)
                return BonoNotFound(id);

            return bono;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(BonoDtoIn bono)
        {
            var newBono = await _service.Create(bono);


            return CreatedAtAction(nameof(GetById), new { id = newBono.Id }, newBono);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BonoDtoIn bono)
        {
            if (id != bono.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({bono.Id}) del cuerpo de la solicitud." });

            var bonoToUpdate = await _service.GetById(id);

            if (bonoToUpdate is not null)
            {
                await _service.Update(id, bono);
                return NoContent();

            }
            else
            {
                return BonoNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var bonoToDelete = await _service.GetById(id);

            if (bonoToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return BonoNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult BonoNotFound(int id)
        {
            return NotFound(new { message = $"El bono con ID = {id} no existe." });
        }
    }
}
