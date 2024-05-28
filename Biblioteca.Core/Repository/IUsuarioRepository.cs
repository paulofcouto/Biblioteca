using Biblioteca.Core.Entities;

namespace Biblioteca.Core.Repository
{
    public interface IUsuarioRepository
    {
        Task CadastrarAssincrono(Usuario usuario);
        Task<List<Usuario>> ObterTodosAssincrono(string query);
    }
}
