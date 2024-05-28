using Biblioteca.Core.Enum;
using MediatR;

namespace Biblioteca.Application.Command.CadastrarUsuario
{
    public class CadastrarUsuarioCommand : IRequest<Unit>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
