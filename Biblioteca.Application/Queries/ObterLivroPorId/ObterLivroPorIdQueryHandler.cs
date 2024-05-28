using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.ObterLivroPorId
{
    public class ObterLivroPorIdQueryHandler : IRequestHandler<ObterLivroPorIdQuery, LivroDetalhadoViewModel?>
    {
        private readonly ILivroRepository _livroRepository;

        public ObterLivroPorIdQueryHandler (ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<LivroDetalhadoViewModel?> Handle(ObterLivroPorIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.ObterPorIdAssincrono(request.Id);

            if (livro == null)
            {
                return null;
            }

            var projectDetailViewModel = new LivroDetalhadoViewModel(
                livro.Id,
                livro.Titulo,
                livro.Autor,
                livro.ISBN,
                livro.AnoDePublicacao,
                livro.Status
                );

            return projectDetailViewModel;
        }
    }
}
