using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oficinas.Application.Commands.CreateServico;
using Oficinas.Application.Commands.DeleteServico;
using Oficinas.Application.Commands.UpdateServico;
using Oficinas.Application.Queries.GetAllServico;
using Oficinas.Application.Queries.GetServicoById;


namespace Oficinas.Api.Controllers
{
    [Route("api/servico")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Cliente, Empregado")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllServicoQuery();
            var getAllServicos = await _mediator.Send(query);

            return Ok(getAllServicos);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Cliente, Empregado")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetServicoByIdQuery(Id);
            var oficina = await _mediator.Send(query);
            if (oficina == null)
            {
                return NotFound();
            }
            return Ok(oficina);
        }
        [HttpPost]
        [Authorize(Roles = "Empregado")]
        public async Task<IActionResult> Post([FromBody] CreateServicoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut]
        [Authorize(Roles = "Empregado")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateServicoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        [Authorize(Roles = "Empregado")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteServicoCommand(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
