using Biblioteca.Core.Entities;

namespace Biblioteca.Core.Repository
{
    public interface IEmprestimoRepository
    {
        Task CadastrarAssincrono(Emprestimo emprestimo);
        Task<List<Emprestimo>> ObterTodosAssincrono();
        Task<string> DevolverLivroAssincrono(int id);
    }
}
