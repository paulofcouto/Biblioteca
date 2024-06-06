using Biblioteca.Core.Entities;

namespace Biblioteca.Core.Repository
{
    public interface ILivroRepository
    {
        Task<int> CadastrarLivroAssincrono(Livro inputModel);
        Task<List<Livro>> ObterTodosAssincrono(string query);
        Task<List<Livro>> ObterTodosDisponiveisAssincrono();
        Task<Livro?> ObterPorIdAssincrono(int id);
        Task RemoverLivroAssincrono(int id);
    }
}
