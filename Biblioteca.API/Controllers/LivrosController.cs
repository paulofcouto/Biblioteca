using Biblioteca.Application.InputModel;
using Biblioteca.Application.Queries.ObterLivroPorId;
using Biblioteca.Application.Queries.ObterTodosLivros;
using Biblioteca.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
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
        public IActionResult ObterPorId(int id)
        {
            var command = new ObterLivroPorIdQuery(id);

            var livro = _mediator.Send(command);

            if(livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string? query = null)
        {
            var command = new ObterTodosLivrosQuery(query);

            var livros = _mediator.Send(command);

            return Ok(livros);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] NovoLivroInputModel inputModel)
        {
            var _id = _livroService.CadastrarLivro(inputModel);

            return CreatedAtAction(nameof(ObterPorId), new { id = _id }, inputModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _livroService.RemoverLivro(id);

            return NoContent();
        }
    }
}
