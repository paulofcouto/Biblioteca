namespace Biblioteca.Core.Entities
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int idUsuario, int idLivro, DateTime dataDeDevolucaoLimite)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataDeRetirada = DateTime.Now;

            if(dataDeDevolucaoLimite == default)
            {
                DataDeDevolucaoLimite = dataDeDevolucaoLimite;
            }
            else
            {
                DataDeDevolucaoLimite = DateTime.Now.AddDays(7);
            }
            
        }

        public int IdUsuario { get; private set; }
        public int IdLivro { get; private set; }
        public DateTime DataDeRetirada { get; private set; }
        public DateTime DataDeDevolucaoLimite { get; private set; }
        public DateTime DataDeDevolucao { get; private set; }


        public void DevolverLivro() 
        {
            DataDeDevolucao = DateTime.Now;
        }
    }
}
