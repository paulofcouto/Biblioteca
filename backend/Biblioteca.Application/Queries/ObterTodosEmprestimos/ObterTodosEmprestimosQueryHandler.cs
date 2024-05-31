using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.ObterTodosEmprestimos
{
    public class ObterTodosEmprestimosQueryHandler : IRequestHandler<ObterTodosEmprestimosQuery, List<EmprestimoViewModel>>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public ObterTodosEmprestimosQueryHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<List<EmprestimoViewModel>> Handle(ObterTodosEmprestimosQuery request, CancellationToken cancellationToken)
        {
            var emprestimos = await _emprestimoRepository.ObterTodosAssincrono(request.Query);

            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                //TODO: montar a lógica para filtrar a query
            }

            var emprestimosViewModel = emprestimos.Select(t => new EmprestimoViewModel(t.Id, t.IdLivro, t.DataDeRetirada, t.DataDeDevolucaoLimite, t.DataDeDevolucao)).ToList();

            return emprestimosViewModel;
        }
    }
}
