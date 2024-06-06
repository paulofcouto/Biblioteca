using Biblioteca.Application.ViewModel;
using MediatR;

namespace Biblioteca.Application.Queries.ObterLivrosDisponiveis
{
    public class ObterLivrosDisponiveisQuery : IRequest<List<LivroDisponivelViewModel>>
    {
    }
}
