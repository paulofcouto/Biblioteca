﻿using Biblioteca.Core.Enum;

namespace Biblioteca.Application.ViewModel
{
    public class LivroViewModel
    {
        public LivroViewModel(int id, string titulo, string autor, string iSBN, int anoDePublicacao, StatusLivroEnum status)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;
            Status = status;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public StatusLivroEnum Status { get; private set; }
    }
}