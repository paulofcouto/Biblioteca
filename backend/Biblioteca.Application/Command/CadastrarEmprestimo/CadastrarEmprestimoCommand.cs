using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Command.CadastrarEmprestimo
{
    public class CadastrarEmprestimoCommand : IRequest<Unit>
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataDeDevolucaoLimite { get; set; }
    }
}
