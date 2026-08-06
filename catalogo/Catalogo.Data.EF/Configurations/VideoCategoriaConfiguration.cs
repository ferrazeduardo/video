using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class VideoCategoriaConfiguration : IEntityTypeConfiguration<VideoCategoria>
{
    public void Configure(EntityTypeBuilder<VideoCategoria> builder)
    {
        builder.HasKey(x => new { x.ID_CATEGORIA, x.ID_VIDEO });
    }
}
