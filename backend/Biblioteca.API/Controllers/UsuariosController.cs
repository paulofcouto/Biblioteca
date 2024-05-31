using Biblioteca.Application.Command.CadastrarUsuario;
using Biblioteca.Application.Queries.ObterTodosUsuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] string? query = null)
        {
            var command = new ObterTodosUsuariosQuery(query);

            var usuarios = await _mediator.Send(command);

            return Ok(usuarios);
        }
    }
}