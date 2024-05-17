using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Application.Services.Implementations
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}