using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class VideoCastFilmeConfiguration : IEntityTypeConfiguration<VideoCastFilme>
{
    public void Configure(EntityTypeBuilder<VideoCastFilme> builder)
    {
       builder.HasKey(x => new {x.ID_CAST_FILME, x.ID_VIDEO});
    }
}
