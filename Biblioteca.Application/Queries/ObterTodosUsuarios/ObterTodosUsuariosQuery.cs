using Biblioteca.Application.ViewModel;
using MediatR;

namespace Biblioteca.Application.Queries.ObterTodosUsuarios
{
    public class ObterTodosUsuariosQuery : IRequest<List<UsuarioViewModel>>
    {
        public ObterTodosUsuariosQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
