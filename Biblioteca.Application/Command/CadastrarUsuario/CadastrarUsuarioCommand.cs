using Biblioteca.Application.InputModel;
using Biblioteca.Core.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Command.CadastrarUsuario
{
    public class CadastrarUsuarioCommand : IRequest<Unit>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
