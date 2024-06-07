using MediatR;

namespace Biblioteca.Application.Command.DevolverLivro
{
    public class DevolverLivroCommand : IRequest<string>
    {
        public DevolverLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
