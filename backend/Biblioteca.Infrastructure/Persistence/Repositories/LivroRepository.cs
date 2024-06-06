using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CadastrarLivroAssincrono(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();

            return livro.Id;
        }

        public async Task<Livro?> ObterPorIdAssincrono(int id)
        {
            var livro = await _dbContext.Livros.SingleOrDefaultAsync(t => t.Id == id);

            return livro;
        }

        public async Task<List<Livro>> ObterTodosAssincrono(string query)
        {
            var livros = await _dbContext.Livros.AsNoTracking().ToListAsync();

            return livros;
        }

        public async Task<List<Livro>> ObterTodosDisponiveisAssincrono()
        {
            var livros = await _dbContext.Livros.AsNoTracking().Where(t => t.Status == Core.Enum.StatusLivroEnum.Disponivel).ToListAsync();

            return livros;
        }

        public async Task RemoverLivroAssincrono(int id)
        {
            var livro = await _dbContext.Livros.SingleOrDefaultAsync(p => p.Id == id);

            if (livro != null)
            {
                _dbContext.Livros.Remove(livro);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
