using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Queries.ObterTodosLivros
{
    public class ObterTodosLivrosQueryHandler : IRequestHandler<ObterTodosLivrosQuery, List<LivroViewModel>>
    {
        private readonly ILivroRepository _livroRepository;
        public ObterTodosLivrosQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<List<LivroViewModel>> Handle(ObterTodosLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.ObterTodosAssincrono(request.Query);

            var livrosViewModel = livros.Select(t => new LivroViewModel(t.Id, t.Titulo, t.Autor, t.ISBN, t.AnoDePublicacao, t.Status)).ToList();

            return livrosViewModel;
        }
    }
}
