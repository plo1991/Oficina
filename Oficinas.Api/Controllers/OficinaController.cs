using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oficinas.Application.Commands.CreateOficina;
using Oficinas.Application.Commands.DeleteOficina;
using Oficinas.Application.Commands.UpdateOficina;
using Oficinas.Application.Queries.GetAllOficinas;
using Oficinas.Application.Queries.GetOficinaById;
using Oficinas.Core.Enums;

namespace Oficinas.Api.Controllers
{
    [Route("api/oficina")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OficinaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOficinasQuery();
            var getAllOficinas = await _mediator.Send(query);

            return Ok(getAllOficinas);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetOficinaByIdQuery(Id);
            var oficina = await _mediator.Send(query);
            if (oficina == null)
            {
                return NotFound();
            }
            return Ok(oficina);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateOficinaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut]
        [Authorize(Roles = "Empregado")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOficinaCommand command)
        {

            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        [Authorize(Roles = "Empregado")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteOficinaCommand(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
