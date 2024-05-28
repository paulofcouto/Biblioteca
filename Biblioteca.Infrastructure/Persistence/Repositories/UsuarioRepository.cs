using Biblioteca.Core.Entities;
using Biblioteca.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public UsuarioRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CadastrarAssincrono(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ObterTodosAssincrono(string query)
        {
            var usuarios = await _dbContext.Usuarios.AsNoTracking().ToListAsync();

            return usuarios;
        }
    }
}
