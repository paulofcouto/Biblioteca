using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Command.CadastrarUsuario
{
    public class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public CadastrarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email, request.TipoUsuario);

            await _usuarioRepository.CadastrarAssincrono(usuario);

            return Unit.Value;
        }
    }
}
