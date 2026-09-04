using System;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;

namespace Catalogo.Data.EF.Repositories;

public class VideoGeneroRepository : IVideoGeneroReporisoty
{
    private readonly CatalogoDbContext _context;

    public VideoGeneroRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public async Task Create(VideoGenero videoGenero, CancellationToken cancellationToken)
    {
        await _context.Set<VideoGenero>().AddAsync(videoGenero, cancellationToken);
    }
}
