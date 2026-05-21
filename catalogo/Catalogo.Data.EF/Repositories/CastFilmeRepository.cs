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

    public Task<SearchOutput<CastFilme>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CastFilme objeto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
