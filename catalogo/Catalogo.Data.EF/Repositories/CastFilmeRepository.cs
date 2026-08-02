using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Data.EF.Repositories;

public class CastFilmeRepository : ICastFilmeRepository
{
    private readonly CatalogoDbContext _context;

    public CastFilmeRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public Task Delete(CastFilme objeto, CancellationToken cancellationToken)
    {
        _context.Set<CastFilme>().Remove(objeto);
        return Task.CompletedTask;
    }

    public async Task<CastFilme> Get(Expression<Func<CastFilme, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
        var query = _context.Set<CastFilme>().AsQueryable();

        if (!rastrer)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro, cancellationToken);
    }

    public async Task Insert(CastFilme objeto, CancellationToken cancellationToken)
    {
        await _context.Set<CastFilme>().AddAsync(objeto, cancellationToken);
    }

    public async Task<SearchOutput<CastFilme>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        var toSkip = (searchInput.Pagina - 1) * searchInput.Quantidade;
        var query = _context.Set<CastFilme>().AsNoTracking();
        query = searchInput.Order == SearchOrder.Desc ? query.OrderByDescending(x => x.Nome) : query.OrderBy(x => x.Nome);

        if (string.IsNullOrEmpty(searchInput.Pesquisa))
            query = query.Where(q => q.Nome.Contains(searchInput.Pesquisa));

        var items = await query.Skip(toSkip).Take(searchInput.Quantidade).ToListAsync();
        var count = await query.CountAsync();
        return new SearchOutput<CastFilme>(searchInput.Pagina, searchInput.Quantidade, count, items);
    }

    public Task Update(CastFilme objeto, CancellationToken cancellationToken)
    {
        _context.Set<CastFilme>().Update(objeto);
        return Task.CompletedTask;
    }

    public async Task<List<CastFilme>?> ListPorIds(List<int> castId, CancellationToken cancellationToken)
    {
        return await _context.Set<CastFilme>().Where(x => castId.Contains(x.id)).ToListAsync(cancellationToken);
    }
}
