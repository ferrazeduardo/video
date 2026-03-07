using System;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;

namespace Catalogo.Application.Interface.Repository;

public interface ICategoriaRepository : IRepository<Categoria>, ISearchRepository<Categoria>
{
}
