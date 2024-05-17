namespace Biblioteca.Application.InputModel
{
    public class NovoEmprestimoInputModel
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataDeDevoluçãoLimite { get; set; }
    }
}