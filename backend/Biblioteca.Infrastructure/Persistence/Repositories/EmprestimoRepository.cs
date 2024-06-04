using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence.Repositories
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
            // Verificando se o LivroId existe
            var livroExiste = await _dbContext.Livros.AnyAsync(l => l.Id == emprestimo.IdLivro);
            if (!livroExiste)
            {
                throw new Exception($"LivroId {emprestimo.IdLivro} não existe.");
            }

            // Verificando se o UsuarioId existe
            var usuarioExiste = await _dbContext.Usuarios.AnyAsync(u => u.Id == emprestimo.IdUsuario);
            if (!usuarioExiste)
            {
                throw new Exception($"UsuarioId {emprestimo.IdUsuario} não existe.");
            }

            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Emprestimo>> ObterTodosAssincrono(string query)
        {
            var emprestimos = await _dbContext.Emprestimos
                .Include(e => e.Usuario)        
                .Include(e => e.Livro)
                .AsNoTracking()
                .ToListAsync();

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
