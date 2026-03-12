using System;
using Catalogo.Application.Interface.Repository;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Data.EF.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly CatalogoDbContext _context;
    private DbSet<Categoria> _categorias => _context.Set<Categoria>();
    public CategoriaRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public Task Delete(Categoria categoria, CancellationToken cancellationToken)
    {
        return Task.FromResult(_categorias.Remove(categoria));
    }

    public async Task<Categoria> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _categorias.AsNoTracking().FirstOrDefaultAsync(x => x.idGuid == id, cancellationToken);
    }

    public async Task Insert(Categoria objeto, CancellationToken cancellationToken)
    {
        await _categorias.AddAsync(objeto, cancellationToken);
    }

    public Task<SearchOutput<Categoria>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(Categoria categoria, CancellationToken cancellationToken)
    {
        return Task.FromResult(_categorias.Update(categoria));
    }
}
