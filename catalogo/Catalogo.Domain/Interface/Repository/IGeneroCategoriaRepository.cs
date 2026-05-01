using System;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface IGeneroCategoriaRepository
{
    Task Create(GenerosCategorias generosCategorias, CancellationToken cancellationToken);
    
}
