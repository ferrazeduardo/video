using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Data.EF.Repositories;

public class GeneroRepository : IGeneroRepository
{
    private readonly CatalogoDbContext _context;

    public GeneroRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public Task Delete(Genero objeto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Genero> Get(Expression<Func<Genero, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
        var query = _context.Set<Genero>().AsQueryable();

        if (!rastrer)
            query = query.AsNoTracking();

        var genero = await query.FirstOrDefaultAsync(filtro, cancellationToken);
        if (genero is null) return null;

        var categoriasIds = await _context.Set<GenerosCategorias>().Where(x => x.ID_GENERO == genero.id).Select(x => x.ID_CATEGORIA).ToListAsync();
        genero.AddCategoria(categoriasIds ?? []);
        return genero;

    }

    public async Task Insert(Genero objeto, CancellationToken cancellationToken)
    {
        await _context.Set<Genero>().AddAsync(objeto, cancellationToken);
    }

    public Task<SearchOutput<Genero>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(Genero objeto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
