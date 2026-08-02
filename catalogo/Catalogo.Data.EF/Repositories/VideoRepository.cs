using System;
using System.Linq.Expressions;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;

namespace Catalogo.Data.EF.Repositories;

public class VideoRepository : IVideoRepository
{
    private readonly CatalogoDbContext _context;

    public VideoRepository(CatalogoDbContext context)
    {
        _context = context;
    }

    public Task Delete(Video objeto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Video> Get(Expression<Func<Video, bool>> filtro, CancellationToken cancellationToken, bool rastrer = true)
    {
        throw new NotImplementedException();
    }

    public Task Insert(Video objeto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SearchOutput<Video>> Search(SearchInput searchInput, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(Video objeto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
