using Biblioteca.Application.InputModel;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Application.ViewModel;
using Biblioteca.Core.Entities;

namespace Biblioteca.Application.Services.Implementations
{
    public class LivroService : ILivroService
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CadastrarLivro(NovoLivroInputModel inputModel)
        {
            var livro = new Livro(inputModel.Titulo, inputModel.Autor, inputModel.ISBN, inputModel.AnoDePublicacao);

            _dbContext.Livros.Add(livro);
            _dbContext.SaveChanges();

            return livro.Id;
        }

        public List<LivroViewModel> ObterTodos(string? query)
        {
            var livros = _dbContext.Livros.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                //TODO: montar a lógica para filtrar a query
            }

            var livrosViewModel = livros.Select(t => new LivroViewModel(t.Id, t.Titulo, t.Autor, t.ISBN, t.AnoDePublicacao, t.Status)).ToList();

            return livrosViewModel;
        }

        public LivroDetalhadoViewModel ObterPorId(int id)
        {
            var livro = _dbContext.Livros.SingleOrDefault(p => p.Id == id);

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

        public void RemoverLivro(int id)
        {
            var livro = _dbContext.Livros.SingleOrDefault(p => p.Id == id);

            if (livro != null)
            {
                _dbContext.Livros.Remove(livro);
                _dbContext.SaveChanges();
            }
        }
    }
}
