using Biblioteca.Application.InputModel;
using Biblioteca.Application.ViewModel;

namespace Biblioteca.Application.Services.Interfaces
{
    public interface ILivroService
    {
        int CadastrarLivro(NovoLivroInputModel inputModel);
        List<LivroViewModel> ObterTodos(string query);
        LivroDetalhadoViewModel ObterPorId(int id);
        void RemoverLivro(int id);
    }
}
