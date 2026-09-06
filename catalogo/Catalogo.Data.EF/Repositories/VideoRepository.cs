using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Data.EF.Repositories;

public class VideoRepository : IVideoRespository
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

    public async Task<Video> Get(Expression<Func<Video, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
       return await _context.Set<Video>().Where(filtro).Include(v => v.Trailer).Include(v => v.Media).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Insert(Video objeto, CancellationToken cancellationToken)
    {
        await _context.Videos.AddAsync(objeto, cancellationToken);
    }

    public async Task<SearchOutput<Video>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        var query = _context.Set<Video>().AsNoTracking();
        query = searchInput.Order == SearchOrder.Desc ? query.OrderByDescending(v => v.Titulo) : query.OrderBy(v => v.Titulo);

        if(!String.IsNullOrEmpty(searchInput.Pesquisa))
            query = query.Where(v => v.Titulo.Contains(searchInput.Pesquisa));
        
        var total = await query.CountAsync(cancellationToken);
        var itens = await query.Skip((searchInput.Pagina - 1) * searchInput.Quantidade).Take(searchInput.Quantidade).ToListAsync(cancellationToken);
        return new (searchInput.Pagina, searchInput.Quantidade, total, itens);
    }

    public Task Update(Video objeto, CancellationToken cancellationToken)
    {
        _context.Set<Video>().Update(objeto);
        return Task.CompletedTask;
    }
}

