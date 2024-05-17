using Biblioteca.Application.InputModel;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var livro = _livroService.ObterPorId(id);

            if(livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string? query = null)
        {
            var livros = _livroService.ObterTodos(query);

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
