using MediatR;

namespace Biblioteca.Application.Command.CadastrarEmprestimo
{
    public class CadastrarEmprestimoCommand : IRequest<Unit>
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataDeDevolucaoLimite { get; set; }
    }
}
