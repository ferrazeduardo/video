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

        builder.OwnsOne(video => video.Thumb, thumb => 
            thumb.Property(image => image.caminho).HasColumnName("ThumbCaminho")
        );

        builder.OwnsOne(video => video.ThumbHalf, thumbHalf => 
            thumbHalf.Property(image => image.caminho).HasColumnName("ThumbHalfCaminho")
        );

        builder.OwnsOne(video => video.banner, banner => 
            banner.Property(imagem => imagem.caminho).HasColumnName("BannerCaminho")
        );

        builder.HasOne(x => x.Media).WithOne().HasForeignKey<Media>();
        builder.HasOne(x => x.Trailer).WithOne().HasForeignKey<Media>();
    }
}
