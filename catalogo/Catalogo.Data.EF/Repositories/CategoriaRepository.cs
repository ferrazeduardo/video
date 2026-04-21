using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;
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

    public async Task Insert(Categoria objeto, CancellationToken cancellationToken)
    {
        await _categorias.AddAsync(objeto, cancellationToken);
    }

    public async Task<SearchOutput<Categoria>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        var query = _categorias.AsNoTracking();
        query = searchInput.Order == SearchOrder.Desc ? query.OrderByDescending(x => x.Nome) : query.OrderBy(x => x.Nome);
        if (!String.IsNullOrEmpty(searchInput.Pesquisa))
            query = query.Where(x => x.Nome.Contains(searchInput.Pesquisa));

        var total = await query.CountAsync(cancellationToken);
        var itens = await query.Skip((searchInput.Pagina - 1) * searchInput.Quantidade).Take(searchInput.Quantidade).ToListAsync();
        return new(searchInput.Pagina, searchInput.Quantidade, total, itens);
    }

    public Task Update(Categoria categoria, CancellationToken cancellationToken)
    {
        return Task.FromResult(_categorias.Update(categoria));
    }

    public async Task<Categoria> Get(Expression<Func<Categoria, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
        var query = _categorias.AsQueryable();

        if (!rastrer)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(filtro, cancellationToken);
    }
}
