using System;
using Catalogo.Domain.Entity;

namespace Catalogo.Application.Interface.Repository;

public interface IRepository<T>
{
    Task Insert(T objeto, CancellationToken cancellationToken);
    Task<T> Get(Guid id, CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Update(T categoria, CancellationToken cancellationToken);

}
