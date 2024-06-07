using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Command.DevolverLivro
{
    public class DevolverLivroCommandHandler : IRequestHandler<DevolverLivroCommand, string>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public DevolverLivroCommandHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<string> Handle(DevolverLivroCommand request, CancellationToken cancellationToken)
        {
            var mensagem = await _emprestimoRepository.DevolverLivroAssincrono(request.Id);

            return mensagem;
        }
    }
}
