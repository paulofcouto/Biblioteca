using Biblioteca.Core.Enum;

namespace Biblioteca.Application.InputModel
{
    public class NovoUsuarioInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}