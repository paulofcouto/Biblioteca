﻿using Biblioteca.Application.Command.CadastrarEmprestimo;
using Biblioteca.Application.Command.DevolverLivro;
using Biblioteca.Application.Queries.ObterLivrosDisponiveis;
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

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            var command = new ObterTodosEmprestimosQuery();

            var emprestimos = await _mediator.Send(command);

            return Ok(emprestimos);
        }

        [HttpGet("ObterLivrosDisponiveis")]
        public async Task<IActionResult> ObterLivrosDisponiveis()
        {
            var command = new ObterLivrosDisponiveisQuery();

            var emprestimos = await _mediator.Send(command);

            return Ok(emprestimos);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarEmprestimoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/devolver")]
        public async Task<IActionResult> Devolver(int id)
        {
            var command = new DevolverLivroCommand(id);

            var resposta = await _mediator.Send(command);

            return Ok(resposta);
        }
    }
}