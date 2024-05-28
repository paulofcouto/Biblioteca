using Biblioteca.Core.Enum;

namespace Biblioteca.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email, TipoUsuarioEnum tipoUsuario)
        {
            Nome = nome;
            Email = email;
            TipoUsuario = tipoUsuario;
            Emprestimos = new List<Emprestimo> { };
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public TipoUsuarioEnum TipoUsuario { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }
    }
}
