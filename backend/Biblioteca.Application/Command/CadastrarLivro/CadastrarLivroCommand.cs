using MediatR;

namespace Biblioteca.Application.Command.CadastrarLivro
{
    public class CadastrarLivroCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePublicacao { get; set; }
    }
}
