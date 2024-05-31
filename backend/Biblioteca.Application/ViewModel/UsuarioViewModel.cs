using Biblioteca.Core.Enum;

namespace Biblioteca.Application.ViewModel
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string email, TipoUsuarioEnum tipoUsuario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            TipoUsuario = tipoUsuario.ObterDisplayName();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string TipoUsuario { get; private set; }
    }
}