using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Infrastructure.Persistence.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(t => t.Emprestimos)
                .WithOne(t => t.Livro)
                .HasForeignKey(t => t.LivroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
