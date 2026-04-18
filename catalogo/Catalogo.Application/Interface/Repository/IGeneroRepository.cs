using System;
using Catalogo.Application.Interface.SearchRepository;

namespace Catalogo.Application.Interface.Repository;

public interface IGeneroRepository : ISearchRepository<Domain.Entity.Genero>, IRepository<Domain.Entity.Genero>
{

}
