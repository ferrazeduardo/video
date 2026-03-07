using System;
using Catalogo.Domain.Entity;

namespace Catalogo.Application.Interface.Repository;

public interface IRepository<T>
{
    Task Insert(T objeto, CancellationToken cancellationToken);
    Task<T> Get(Guid id);
    Task Delete(Guid id, CancellationToken cancellationToken);
}
