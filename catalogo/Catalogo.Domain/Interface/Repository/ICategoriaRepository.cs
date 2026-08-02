using System;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface ICategoriaRepository : IRepository<Categoria>, ISearchRepository<Categoria>
{
    Task<List<Categoria>?> ListPorIds(List<int> categoriasId, CancellationToken cancellationToken);
}
