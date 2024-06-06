namespace Biblioteca.Application.ViewModel
{
    public class LivroDisponivelViewModel
    {
        public LivroDisponivelViewModel(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }

    }
}