using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Command.DeletarLivro
{
    public class DeletarLivroCommandHandler : IRequestHandler<DeletarLivroCommand, Unit>
    {
        private readonly ILivroRepository _livroRepository;

        public DeletarLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<Unit> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
        {
            await _livroRepository.RemoverLivroAssincrono(request.Id);

            return Unit.Value;
        }
    }
}
