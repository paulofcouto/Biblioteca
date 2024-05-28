using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {

        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Usuario>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Emprestimo>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(t => t.Usuario)
                .WithMany(t => t.Emprestimos)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(t => t.Livro)
                .WithMany(t => t.Emprestimos)
                .HasForeignKey(t => t.IdLivro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
