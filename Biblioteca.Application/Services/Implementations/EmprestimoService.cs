using Biblioteca.Application.InputModel;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Entities;

namespace Biblioteca.Application.Services.Implementations
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly BibliotecaDbContext _dbContext;

        public EmprestimoService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CadastrarEmprestimo(NovoEmprestimoInputModel inputModel)
        {
            var emprestimo = new Emprestimo(inputModel.IdUsuario, inputModel.IdLivro, inputModel.DataDeDevoluçãoLimite);

            _dbContext.Emprestimos.Add(emprestimo);
            _dbContext.SaveChanges();

            return emprestimo.Id;
        }

        public List<EmprestimoViewModel> ObterTodosEmprestimos(string query)
        {
            var emprestimos = _dbContext.Emprestimos;

            var emprestimosViewModel = emprestimos.Select(t => new EmprestimoViewModel(t.Id, t.IdLivro, t.DataDeRetirada, t.DataDeDevolucaoLimite, t.DataDeDevolucao)).ToList();

            return emprestimosViewModel;
        }

        public void DevolverLivro(int id)
        {
            var livro = _dbContext.Livros.SingleOrDefault(p => p.Id == id);
            var emprestimo = _dbContext.Emprestimos.SingleOrDefault(p => p.Id == id);

            if(livro != null && emprestimo != null) 
            {
                emprestimo.DevolverLivro();
                livro.DevolverLivro();
                _dbContext.SaveChanges();
            }
        }
    }
}
