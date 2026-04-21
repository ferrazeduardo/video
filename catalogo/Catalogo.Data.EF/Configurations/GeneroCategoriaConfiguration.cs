using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class GeneroCategoriaConfiguration : IEntityTypeConfiguration<GenerosCategorias>
{
    public void Configure(EntityTypeBuilder<GenerosCategorias> builder)
    {
        builder.HasKey(x => new { x.ID_CATEGORIA, x.ID_GENERO });
    }
}
