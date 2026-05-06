using System;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface ICastFilmeRepository : IRepository<CastFilme>, ISearchRepository<CastFilme>
{

}
