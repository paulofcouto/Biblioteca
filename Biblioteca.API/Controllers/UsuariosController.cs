using Biblioteca.Application.InputModel;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] NovoUsuarioInputModel inputModel)
        {
            var _id = _usuarioService.CadastrarUsuario(inputModel);

            return NoContent();
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] string? query = null)
        {
            var usuarios = _usuarioService.ObterTodosUsuarios(query);

            return Ok(usuarios);
        }
    }
}