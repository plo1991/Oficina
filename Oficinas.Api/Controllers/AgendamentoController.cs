using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oficinas.Application.Commands.CreateAgendamento;
using Oficinas.Application.Commands.UpdateAgendamento;
using Oficinas.Application.Queries.GetAllAgendamento;
using Oficinas.Application.Queries.GetAgendamentoById;
using Oficinas.Application.Commands.DeleteAgendamento;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Oficinas.Application.Queries.GetAgendamentoByDate;

namespace Oficinas.Api.Controllers
{
    [Route("api/agendamento")]
    [ApiController]
    [Authorize]
    public class AgendamentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AgendamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllAgendamentoQuery();
            var getAllAgendamentos = await _mediator.Send(query);

            return Ok(getAllAgendamentos);
        }
        [HttpGet("getbydate")]
        public async Task<IActionResult> GetByDate(DateTime dataInicio, DateTime dataFim)
        {
            var query = new GetAgendamentoByDateQuery(dataInicio,dataFim);
            var agendamentosByDate = await _mediator.Send(query);

            return Ok(agendamentosByDate);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetAgendamentoByIdQuery(Id);
            var oficina = await _mediator.Send(query);
            if (oficina == null)
            {
                return NotFound();
            }
            return Ok(oficina);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAgendamentoCommand command)
        {
            var id = await _mediator.Send(command);
            if (id == 0) return BadRequest("Carga de trabalho diaria atingida");
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAgendamentoCommand command)
        {

            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteAgendamentoCommand(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
