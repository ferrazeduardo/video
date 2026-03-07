using System;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Application.Interface.SearchRepository;

public interface ISearchRepository<T> where T : AggregationRoot 
{
    Task<SearchOutput<T>> Search(SearchInput searchInput,CancellationToken cancellationToken);
}
