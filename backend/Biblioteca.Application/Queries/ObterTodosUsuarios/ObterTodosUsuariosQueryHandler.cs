using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Queries.ObterTodosUsuarios
{
    public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, List<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ObterTodosUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<UsuarioViewModel>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.ObterTodosAssincrono(request.Query);

            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                //TODO: montar a lógica para filtrar a query
            }

            var usuariosViewModel = usuarios.Select(t => new UsuarioViewModel(t.Id, t.Nome, t.Email, t.TipoUsuario)).ToList();

            return usuariosViewModel;
        }
    }
}
