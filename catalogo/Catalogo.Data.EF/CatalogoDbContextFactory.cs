using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Catalogo.Data.EF;
//EF Core conseguir criar o DbContext fora da inicialização da aplicação, mesmo sem acesso ao Program.cs e ao appsettings padrão.
//EF CLI roda fora da aplicação
public class CatalogoDbContextFactory : IDesignTimeDbContextFactory<CatalogoDbContext>
{
    public CatalogoDbContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Catalogo.Api");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CatalogoDbContext>();

        optionsBuilder.UseNpgsql(
            configuration.GetConnectionString("CatalogoDb"));

        return new CatalogoDbContext(optionsBuilder.Options);
    }
}
