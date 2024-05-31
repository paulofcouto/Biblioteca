using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Enum
{
    public enum StatusLivroEnum
    {
        None = 0,

        [Display(Name = "Disponível")]
        Disponivel = 1,

        [Display(Name = "Indisponível")]
        Indisponivel = 2,

        Emprestado = 3,

        Perdido = 4
    }
}
