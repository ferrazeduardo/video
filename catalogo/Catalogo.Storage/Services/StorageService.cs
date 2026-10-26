using System;
using Catalogo.Application.Interfaces;
using Catalogo.Storage.Configuration;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Options;

namespace Catalogo.Storage.Services;

public class StorageService : IStorageService
{
    private StorageClient _storageClient;
    private IOptions<StorageServiceOptions> _options;

    public StorageService(StorageClient storageClient, IOptions<StorageServiceOptions> options)
    {
        _storageClient = storageClient;
        _options = options;
    }

    public Task Delete(string arquivoNome, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> Upload(string arquivoNome, Stream arquivoStream, string contentType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
