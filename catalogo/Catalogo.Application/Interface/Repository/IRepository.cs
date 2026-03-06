using System;

namespace Catalogo.Application.Interface.Repository;

public interface IRepository<T>
{
    Task Insert(T categoria,CancellationToken cancellationToken);

}
