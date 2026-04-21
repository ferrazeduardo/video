using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;

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

    public Task<Genero> Get(Expression<Func<Genero, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(Genero objeto, CancellationToken cancellationToken)
    {
        await _context.AddAsync(objeto, cancellationToken);
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
