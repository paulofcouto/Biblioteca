﻿using Biblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Biblioteca.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(t => t.Emprestimos)
                .WithOne()
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
