using System;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;

namespace Catalogo.Data.EF.Repositories;

public class VideoCastFilmeRepository : IVideoCastFilmeRepository
{
    private readonly CatalogoDbContext _context;

    public VideoCastFilmeRepository(CatalogoDbContext context)
    {
        _context = context;
    }
    public async Task Create(VideoCastFilme videoCastFilme, CancellationToken cancellationToken)
    {
        await _context.Set<VideoCastFilme>().AddAsync(videoCastFilme, cancellationToken);
    }
}
