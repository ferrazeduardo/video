using System;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;

namespace Catalogo.Data.EF.Repositories;

public class GeneroCategoriaRepository : IGeneroCategoriaRepository
{
    private CatalogoDbContext _catalogoDbContext;

    public GeneroCategoriaRepository(CatalogoDbContext catalogoDbContext)
    {
        _catalogoDbContext = catalogoDbContext;
    }
    
    public async Task Create(GenerosCategorias generosCategorias, CancellationToken cancellationToken)
    {
        await _catalogoDbContext.Set<GenerosCategorias>().AddAsync(generosCategorias, cancellationToken);
    }
}
