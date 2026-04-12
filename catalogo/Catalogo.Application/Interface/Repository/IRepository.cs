using System;
using System.Linq.Expressions;
using Catalogo.Domain.Entity;

namespace Catalogo.Application.Interface.Repository;

public interface IRepository<T>
{
    Task Insert(T objeto, CancellationToken cancellationToken);
    Task<T> Get(Expression<Func<T, bool>> filtro, CancellationToken cancellationToken);
    Task Delete(T objeto, CancellationToken cancellationToken);
    Task Update(T objeto, CancellationToken cancellationToken);

}
