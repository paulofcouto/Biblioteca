using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Queries.ObterLivrosDisponiveis
{
    public class ObterLivrosDisponiveisQueryHandler : IRequestHandler<ObterLivrosDisponiveisQuery, List<LivroDisponivelViewModel>>
    {
        private readonly ILivroRepository _livroRepository;
        public ObterLivrosDisponiveisQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<List<LivroDisponivelViewModel>> Handle(ObterLivrosDisponiveisQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.ObterTodosDisponiveisAssincrono();

            var livrosViewModel = livros.Select(t => new LivroDisponivelViewModel(t.Id, t.Titulo)).ToList();

            return livrosViewModel;
        }

    }
}
