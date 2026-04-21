using System;
using Catalogo.Application.Interface.SearchRepository;

namespace Catalogo.Domain.Interface.Repository;

public interface IGeneroRepository : ISearchRepository<Domain.Entity.Genero>, IRepository<Domain.Entity.Genero>
{

}
