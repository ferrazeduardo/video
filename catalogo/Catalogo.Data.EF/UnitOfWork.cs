using System;
using Catalogo.Application.Interface;

namespace Catalogo.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly CatalogoDbContext _context;
    public UnitOfWork(CatalogoDbContext context)
    {
        _context = context;
    }
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
