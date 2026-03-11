using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.id);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(255);
        builder.Property(c => c.Descricao).HasMaxLength(10_000);
        builder.Property(c => c.Status).IsRequired().HasMaxLength(1);
    }
}
