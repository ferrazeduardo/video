using System;

namespace Catalogo.Application.Interfaces;

public interface IStorageService
{
    Task<String> Upload(string arquivoNome, Stream arquivoStream,CancellationToken cancellationToken);
}
