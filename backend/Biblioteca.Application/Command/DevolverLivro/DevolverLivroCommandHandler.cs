using Biblioteca.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Command.DevolverLivro
{
    public class DevolverLivroCommandHandler : IRequestHandler<DevolverLivroCommand, Unit>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public DevolverLivroCommandHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<Unit> Handle(DevolverLivroCommand request, CancellationToken cancellationToken)
        {
            await _emprestimoRepository.DevolverLivroAssincrono(request.Id);

            return Unit.Value;
        }
    }
}
