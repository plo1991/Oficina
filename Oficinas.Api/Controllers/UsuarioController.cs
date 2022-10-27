using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oficinas.Application.Commands.CreateUsuario;
using Oficinas.Application.Commands.LoginUsuario;
using Oficinas.Application.Queries.GetUsuarioById;

namespace Oficinas.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUsuarioByIdQuery(id);
            var usuario = await _mediator.Send(query);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        // api/usuarios/login   
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command)
        {
            var loginUsuarioViewModel = await _mediator.Send(command);

            if (loginUsuarioViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUsuarioViewModel);
        }
    }
}
