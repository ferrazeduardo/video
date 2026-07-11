using System;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface IGeneroRepository : ISearchRepository<Domain.Entity.Genero>, IRepository<Domain.Entity.Genero>
{
    Task<List<Genero>?> ListPorIds(List<Guid> generosId, CancellationToken cancellationToken);
}
