using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using MediatR;

namespace Biblioteca.Application.Command.CadastrarEmprestimo
{
    public class CadastrarEmprestimoCommandHandler : IRequestHandler<CadastrarEmprestimoCommand, Unit>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public CadastrarEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository) 
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<Unit> Handle(CadastrarEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = new Emprestimo(request.IdUsuario, request.IdLivro, request.DataDeDevolucaoLimite);
            
            await _emprestimoRepository.CadastrarAssincrono(emprestimo);

            return Unit.Value;
        }
    }
}
