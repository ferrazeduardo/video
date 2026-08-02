using System;
using Catalogo.Data.EF.Configurations;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Catalogo.Data.EF;

public class CatalogoDbContext : DbContext
{
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<GenerosCategorias> GenerosCategorias => Set<GenerosCategorias>();
    public DbSet<CastFilme> CastFilmes => Set<CastFilme>();
    public DbSet<Video> Videos => Set<Video>();

    public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new GeneroConfiguration());
        modelBuilder.ApplyConfiguration(new GeneroCategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new CastFilmeConfiguration());
        modelBuilder.ApplyConfiguration(new VIdeoConfiguration());
    }
}
