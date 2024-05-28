using Biblioteca.Application.ViewModel;
using MediatR;

namespace Biblioteca.Application.Queries.ObterTodosEmprestimos
{
    public class ObterTodosEmprestimosQuery : IRequest<List<EmprestimoViewModel>>
    {
        public ObterTodosEmprestimosQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
