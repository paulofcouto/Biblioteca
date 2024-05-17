using Biblioteca.Application.InputModel;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimosController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }


        [HttpPost]
        public IActionResult Cadastrar([FromBody] NovoEmprestimoInputModel inputModel)
        {
            var _id = _emprestimoService.CadastrarEmprestimo(inputModel);

            return NoContent();
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string? query = null)
        {
            var emprestimos = _emprestimoService.ObterTodosEmprestimos(query);

            return Ok(emprestimos);
        }

        [HttpPut("{id}/devolver")]
        public IActionResult Devolver(int id)
        {
            _emprestimoService.DevolverLivro(id);

            return NoContent();
        }
    }
}