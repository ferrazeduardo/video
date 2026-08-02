using System;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Data.EF.Configurations;

public class VIdeoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        throw new NotImplementedException();
    }
}
