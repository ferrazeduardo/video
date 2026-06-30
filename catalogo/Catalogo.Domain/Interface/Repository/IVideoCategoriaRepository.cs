using System;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface IVideoCategoriaRepository
{
    Task Create(VideoCategoria videoCategoria, CancellationToken cancellationToken);
}
