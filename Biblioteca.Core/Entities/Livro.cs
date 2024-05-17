using Biblioteca.Core.Enum;

namespace Biblioteca.Core.Entities
{
    public class Livro : BaseEntity
    {
        public Livro(string titulo, string autor, string iSBN, int anoDePublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;
            Status = StatusLivroEnum.Disponivel;
        }

        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public StatusLivroEnum Status { get; private set; }

        public void DevolverLivro()
        {
            Status = StatusLivroEnum.Disponivel;
        }
    }
}
