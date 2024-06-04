namespace Biblioteca.Application.ViewModel
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(string nomeUsuario, string tituloLivro, DateTime dataDeRetirada, DateTime dataDeDevolucaoLimite, DateTime dataDeDevolucao)
        {
            NomeUsuario = nomeUsuario;
            TituloLivro = tituloLivro;
            DataDeRetirada = dataDeRetirada;
            DataDeDevolucaoLimite = dataDeDevolucaoLimite;
            DataDeDevolucao = dataDeDevolucao;
        }

        public string NomeUsuario { get; private set; }
        public string TituloLivro { get; private set; }
        public DateTime DataDeRetirada { get; private set; }
        public DateTime DataDeDevolucaoLimite { get; private set; }
        public DateTime DataDeDevolucao { get; private set; }
    }
}