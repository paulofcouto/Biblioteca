using Biblioteca.Application.Command.CadastrarLivro;
using Biblioteca.Application.Command.DeletarLivro;
using Biblioteca.Application.Queries.ObterLivroPorId;
using Biblioteca.Application.Queries.ObterTodosLivros;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LivrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var command = new ObterLivroPorIdQuery(id);

            var livro = await _mediator.Send(command);

            if(livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] string? query = null)
        {
            var command = new ObterTodosLivrosQuery(query);

            var livros = await _mediator.Send(command);

            return Ok(livros);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarLivroCommand command)
        {
            var _id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterPorId), new { id = _id }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletarLivroCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
