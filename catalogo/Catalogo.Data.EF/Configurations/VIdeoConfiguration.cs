using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class VIdeoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(video => video.id);
        builder
        .Property(video => video.Titulo)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(video => video.Descricao)
        .HasMaxLength(10000);
    }
}
