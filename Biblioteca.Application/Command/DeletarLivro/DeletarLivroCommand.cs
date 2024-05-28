using MediatR;

namespace Biblioteca.Application.Command.DeletarLivro
{
    public class DeletarLivroCommand : IRequest<Unit>
    {
        public DeletarLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
