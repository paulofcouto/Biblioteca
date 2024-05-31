using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Persistence.Configurations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasOne(t => t.Usuario)
                .WithMany(t => t.Emprestimos)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Livro)
                .WithMany(t => t.Emprestimos)
                .HasForeignKey(t => t.IdLivro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
