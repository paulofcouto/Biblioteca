using Biblioteca.Application.Command.CadastrarEmprestimo;
using Biblioteca.Application.Command.DevolverLivro;
using Biblioteca.Application.Queries.ObterTodosEmprestimos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmprestimosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string? query = null)
        {
            var command = new ObterTodosEmprestimosQuery(query);

            var emprestimos = _mediator.Send(command);

            return Ok(emprestimos);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarEmprestimoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/devolver")]
        public IActionResult Devolver(int id)
        {
            var command = new DevolverLivroCommand(id);

            _mediator.Send(command);

            return NoContent();
        }
    }
}