using System;
using System.IO;
using Catalogo.Application.Interfaces;

namespace Catalogo.Data.EF.Storage;

public class LocalStorageService : IStorageService
{
    private readonly string _basePath;

    public LocalStorageService()
    {
        _basePath = Path.Combine(Directory.GetCurrentDirectory(), "StorageFiles");
        Directory.CreateDirectory(_basePath);
    }

    public async Task<string> Upload(string arquivoNome, Stream arquivoStream, CancellationToken cancellationToken)
    {
        var caminho = Path.Combine(_basePath, arquivoNome);
        using var fileStream = new FileStream(caminho, FileMode.Create);
        await arquivoStream.CopyToAsync(fileStream, cancellationToken);
        return arquivoNome;
    }

    public Task Delete(string arquivoNome, CancellationToken cancellationToken)
    {
        var caminho = Path.Combine(_basePath, arquivoNome);
        if (File.Exists(caminho))
            File.Delete(caminho);

        return Task.CompletedTask;
    }
}
