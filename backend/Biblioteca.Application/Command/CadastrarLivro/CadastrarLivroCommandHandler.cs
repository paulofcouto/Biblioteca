using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Command.CadastrarLivro
{
    public class CadastrarLivroCommandHandler : IRequestHandler<CadastrarLivroCommand, int>
    {
        private readonly ILivroRepository _livroRepository;

        public CadastrarLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<int> Handle(CadastrarLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro(request.Titulo, request.Autor, request.ISBN, request.AnoDePublicacao);

            var id = await _livroRepository.CadastrarLivroAssincrono(livro);

            return id;
        }
    }
}
