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

    public async Task Delete(Genero objeto, CancellationToken cancellationToken)
    {
        var categoriesIds = await _context.Set<GenerosCategorias>().Where(x => x.ID_GENERO == objeto.id).ToListAsync();
        _context.Set<GenerosCategorias>().RemoveRange(categoriesIds);
        _context.Set<Genero>().Remove(objeto);
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

    public async Task<SearchOutput<Genero>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        var query = _context.Set<Genero>().AsNoTracking();
        query = OrderQuery(query,searchInput.Ordernacao,searchInput.Order);

        if (!string.IsNullOrEmpty(searchInput.Pesquisa))
            query = query.Where(x => x.Nome.Contains(searchInput.Pesquisa));

        var total = await query.CountAsync(cancellationToken);
        var itens = await query.Skip((searchInput.Pagina - 1) * searchInput.Quantidade).Take(searchInput.Quantidade).ToListAsync();
        return new(searchInput.Pagina, searchInput.Quantidade, total, itens);
    }

    public Task Update(Genero objeto, CancellationToken cancellationToken)
    {
        _context.Set<Genero>().Update(objeto);

        return Task.CompletedTask;
    }


    public IQueryable<Genero> OrderQuery(IQueryable<Genero> query, string orderProperty, SearchOrder order)
    {
        var orderQuery = (orderProperty.ToLower(), order) switch
        {
            ("nome", SearchOrder.Asc) => query.OrderBy(x => x.Nome).ThenBy(x => x.id),
            ("nome", SearchOrder.Desc) => query.OrderByDescending(x => x.Nome).ThenBy(x => x.id)
        };

        return orderQuery;


    }
}
