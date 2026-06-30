using System;
using Catalogo.Domain.Entity;

namespace Catalogo.Domain.Interface.Repository;

public interface IVideoGeneroReporisoty
{
    Task Create(VideoGenero videoGenero, CancellationToken cancellationToken);
}
