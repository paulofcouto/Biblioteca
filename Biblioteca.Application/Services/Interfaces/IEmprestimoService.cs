using Biblioteca.Application.InputModel;
using Biblioteca.Application.ViewModel;

namespace Biblioteca.Application.Services.Interfaces
{
    public interface IEmprestimoService
    {
        int CadastrarEmprestimo(NovoEmprestimoInputModel inputModel);
        void DevolverLivro(int id);
        List<EmprestimoViewModel> ObterTodosEmprestimos(string query);
    }
}
