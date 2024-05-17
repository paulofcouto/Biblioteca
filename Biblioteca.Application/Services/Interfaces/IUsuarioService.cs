using Biblioteca.Application.InputModel;
using Biblioteca.Application.ViewModel;

namespace Biblioteca.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        int CadastrarUsuario(NovoUsuarioInputModel inputModel);
        List<UsuarioViewModel> ObterTodosUsuarios(string query);
    }
}
