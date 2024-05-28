using Biblioteca.Application.ViewModel;
using MediatR;

namespace Biblioteca.Application.Queries.ObterTodosLivros
{
    public class ObterTodosLivrosQuery : IRequest<List<LivroViewModel>>
    {
        public ObterTodosLivrosQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
