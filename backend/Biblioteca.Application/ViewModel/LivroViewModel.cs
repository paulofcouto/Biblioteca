using Biblioteca.Core.Enum;

namespace Biblioteca.Application.ViewModel
{
    public class LivroViewModel
    {
        public LivroViewModel(int id, string titulo, string autor, string iSBN, int anoDePublicacao, StatusLivroEnum status, bool possuiEmprestimo)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;
            Status = status.ObterDisplayName();
            PossuiEmprestimo = possuiEmprestimo;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public string Status { get; private set; }
        public bool PossuiEmprestimo { get; set; }
    }
}