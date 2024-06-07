namespace Biblioteca.Core.Entities
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int usuarioId, int livroId, DateTime dataDeDevolucaoLimite)
        {
            UsuarioId = usuarioId;
            LivroId = livroId;

            DataDeRetirada = DateTime.Now;

            if(dataDeDevolucaoLimite != default)
            {
                DataDeDevolucaoLimite = dataDeDevolucaoLimite;
            }
            else
            {
                DataDeDevolucaoLimite = DateTime.Now.AddDays(7);
            }
            
        }

        public Usuario Usuario { get; private set; }
        public int UsuarioId { get; private set; }
        public Livro Livro { get; private set; }
        public int LivroId { get; private set; }
        public DateTime DataDeRetirada { get; private set; }
        public DateTime DataDeDevolucaoLimite { get; private set; }
        public DateTime DataDeDevolucao { get; private set; }


        public void DevolverLivro() 
        {
            DataDeDevolucao = DateTime.Now;
        }
    }
}
