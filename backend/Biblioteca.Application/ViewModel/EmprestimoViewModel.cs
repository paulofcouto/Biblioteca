namespace Biblioteca.Application.ViewModel
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(string nomeUsuario, string tituloLivro, DateTime dataDeRetirada, DateTime dataDeDevolucaoLimite, DateTime dataDeDevolucao, int id)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            TituloLivro = tituloLivro;
            DataDeRetirada = dataDeRetirada;
            DataDeDevolucaoLimite = dataDeDevolucaoLimite;

            if(dataDeDevolucao != default(DateTime))
            {
                DataDeDevolucao = dataDeDevolucao;
            }
            else
            {
                DataDeDevolucao = null;
            }
            
        }

        public int Id { get; private set; }
        public string NomeUsuario { get; private set; }
        public string TituloLivro { get; private set; }
        public DateTime DataDeRetirada { get; private set; }
        public DateTime DataDeDevolucaoLimite { get; private set; }
        public DateTime? DataDeDevolucao { get; private set; }
    }
}