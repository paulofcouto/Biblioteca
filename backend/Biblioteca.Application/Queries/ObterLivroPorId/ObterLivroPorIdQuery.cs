using Biblioteca.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.ObterLivroPorId
{
    public class ObterLivroPorIdQuery : IRequest<LivroDetalhadoViewModel?>
    {
        public ObterLivroPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
