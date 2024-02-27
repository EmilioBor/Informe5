using Core.Request;
using Core.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Informe5Grupo4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        private readonly IEntregaService _service;

        public EntregaController(IEntregaService entrega)
        {
            _service = entrega;
        }


        [HttpGet]
        public async Task<IEnumerable<EntregaDtoOut>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EntregaDtoOut>> GetById(int id)
        {
            var entrega = await _service.GetDtoById(id);

            if (entrega is null)
                return EntregaNotFound(id);

            return entrega;
        }


        //AGREGAR
        [HttpPost]
        public async Task<IActionResult> Create(EntregaDtoIn entrega)
        {
            var newEntrega = await _service.Create(entrega);


            return CreatedAtAction(nameof(GetById), new { id = newEntrega.Id }, newEntrega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EntregaDtoIn entrega)
        {
            if (id != entrega.Id)
                return BadRequest(new { message = $"El ID = {id} de la URL no coincide con el ID({entrega.Id}) del cuerpo de la solicitud." });

            var entregaToUpdate = await _service.GetById(id);

            if (entregaToUpdate is not null)
            {
                await _service.Update(id, entrega);
                return NoContent();

            }
            else
            {
                return EntregaNotFound(id);

            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var entregaToDelete = await _service.GetById(id);

            if (entregaToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();

            }
            else
            {
                return EntregaNotFound(id);

            }

        }

        [NonAction]

        public NotFoundObjectResult EntregaNotFound(int id)
        {
            return NotFound(new { message = $"El entrega con ID = {id} no existe." });
        }
    }
}
