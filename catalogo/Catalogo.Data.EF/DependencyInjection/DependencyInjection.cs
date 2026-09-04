using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Interface.Repository;
using Catalogo.Data.EF.Repositories;
using Catalogo.Data.EF.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.Data.EF.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDataEF(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IGeneroRepository, GeneroRepository>();
        services.AddScoped<IGeneroCategoriaRepository, GeneroCategoriaRepository>();
        services.AddScoped<ICastFilmeRepository, CastFilmeRepository>();
        services.AddScoped<IVideoRespository, VideoRepository>();
        services.AddScoped<IVideoCastFilmeRepository, VideoCastFilmeRepository>();
        services.AddScoped<IVideoCategoriaRepository, VIdeoCategoriaRepository>();
        services.AddScoped<IVideoGeneroReporisoty, VideoGeneroRepository>();
        services.AddScoped<IStorageService, LocalStorageService>();
        services.AddDbContext<CatalogoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("CatalogoDb")));
        return services;
    }
}
