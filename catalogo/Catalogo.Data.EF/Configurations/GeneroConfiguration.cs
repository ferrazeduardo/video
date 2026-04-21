using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.HasKey(x => x.id);

        builder.Property(g => g.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Status)
            .IsRequired();

        builder.Property(g => g.dataCriacao)
            .IsRequired();

        // builder.HasMany<GenerosCategorias>("categorias")
        // .WithOne()
        // .HasForeignKey(x => x.ID_GENERO);
    }
}
