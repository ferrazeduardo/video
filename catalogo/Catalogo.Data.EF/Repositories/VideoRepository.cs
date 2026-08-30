using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Data.EF.Repositories;

public class VideoRepository : IVideoRepository
{
    private readonly CatalogoDbContext _context;

    public VideoRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public Task Delete(Video objeto, CancellationToken cancellationToken)
    {
        _context.Set<VideoCategoria>().RemoveRange(_context.Set<VideoCategoria>().Where(v => v.ID_VIDEO == objeto.id));
        _context.Set<VideoCastFilme>().RemoveRange(_context.Set<VideoCastFilme>().Where(v => v.ID_VIDEO == objeto.id));
        _context.Set<VideoGenero>().RemoveRange(_context.Set<VideoGenero>().Where(v => v.ID_VIDEO == objeto.id));

        if (objeto.Trailer is not null)
        {
            _context.Set<Media>().Remove(objeto.Trailer);
        }

        if(objeto.Media is not null)
        {
            _context.Set<Media>().Remove(objeto.Media);
        }

        _context.Set<Video>().Remove(objeto);
        return Task.CompletedTask;
    }

    public Task<Video> Get(Expression<Func<Video, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(Video objeto, CancellationToken cancellationToken)
    {
        await _context.Videos.AddAsync(objeto, cancellationToken);
    }

    public Task<SearchOutput<Video>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(Video objeto, CancellationToken cancellationToken)
    {
        _context.Set<Video>().Update(objeto);
        return Task.CompletedTask;
    }
}

