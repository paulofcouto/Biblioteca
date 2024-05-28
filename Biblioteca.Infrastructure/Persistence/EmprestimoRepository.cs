using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public EmprestimoRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CadastrarAssincrono(Emprestimo emprestimo)
        {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Emprestimo>> ObterTodosAssincrono(string query)
        {
            var emprestimos = await _dbContext.Emprestimos.AsNoTracking().ToListAsync();

            return emprestimos;
        }

        public async Task DevolverLivroAssincrono(int id)
        {
            var livro = await _dbContext.Livros.SingleOrDefaultAsync(p => p.Id == id);
            var emprestimo = await _dbContext.Emprestimos.SingleOrDefaultAsync(p => p.Id == id);

            if (livro != null && emprestimo != null)
            {
                emprestimo.DevolverLivro();
                livro.MarcarDisponivel();
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
