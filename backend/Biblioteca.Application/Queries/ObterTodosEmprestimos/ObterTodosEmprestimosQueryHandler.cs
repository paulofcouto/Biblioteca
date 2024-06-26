﻿using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Repository;
using MediatR;

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
            var emprestimos = await _emprestimoRepository.ObterTodosAssincrono();

            var emprestimosViewModel = emprestimos.Select(t => new EmprestimoViewModel(t.Usuario.Nome, t.Livro.Titulo, t.DataDeRetirada, t.DataDeDevolucaoLimite, t.DataDeDevolucao, t.Id)).ToList();

            return emprestimosViewModel;
        }
    }
}
