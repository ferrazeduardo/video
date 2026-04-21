using System;

namespace Catalogo.Application.Interface;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
