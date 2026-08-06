using System;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;

namespace Catalogo.Data.EF.Repositories;

public class VIdeoCategoriaRepository : IVideoCategoriaRepository
{
    private CatalogoDbContext _context;

    public VIdeoCategoriaRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public async Task Create(VideoCategoria videoCategoria, CancellationToken cancellationToken)
    {
        await _context.Set<VideoCategoria>().AddAsync(videoCategoria, cancellationToken);
    }
}
