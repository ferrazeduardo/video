using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class CastFilmeConfiguration : IEntityTypeConfiguration<CastFilme>
{
    public void Configure(EntityTypeBuilder<CastFilme> builder)
    {
        builder.HasKey(x => x.id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Tipo)
            .IsRequired();

        builder.Property(x => x.DataCriacao)
            .IsRequired();
    }
}
