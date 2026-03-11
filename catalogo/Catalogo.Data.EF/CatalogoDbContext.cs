using System;
using Catalogo.Data.EF.Configurations;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Catalogo.Data.EF;

public class CatalogoDbContext : DbContext
{
    public DbSet<Categoria> Categorias => Set<Categoria>();

    public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
    }
}
