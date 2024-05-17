namespace Biblioteca.Application.ViewModel
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(int idUsuario, int idLivro, DateTime dataDeRetirada, DateTime dataDeDevolucaoLimite, DateTime dataDeDevolucao)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataDeRetirada = dataDeRetirada;
            DataDeDevolucaoLimite = dataDeDevolucaoLimite;
            DataDeDevolucao = dataDeDevolucao;
        }

        public int IdUsuario { get; private set; }
        public int IdLivro { get; private set; }
        public DateTime DataDeRetirada { get; private set; }
        public DateTime DataDeDevolucaoLimite { get; private set; }
        public DateTime DataDeDevolucao { get; private set; }
    }
}