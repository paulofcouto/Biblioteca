using MediatR;

namespace Biblioteca.Application.Command.DevolverLivro
{
    public class DevolverLivroCommand : IRequest<Unit>
    {
        public DevolverLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
