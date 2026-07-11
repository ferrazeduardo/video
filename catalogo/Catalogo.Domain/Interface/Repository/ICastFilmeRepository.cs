using System;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface ICastFilmeRepository : IRepository<CastFilme>, ISearchRepository<CastFilme>
{
    Task<List<CastFilme>?> ListPorIds(List<Guid> castId, CancellationToken cancellationToken);
}
