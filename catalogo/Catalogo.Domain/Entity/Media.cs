using System;
using Catalogo.Domain.Enum;

namespace Catalogo.Domain.Entity;

public class Media
{
    public Media(string caminhoArquivo)
    {
        CaminhoArquivo = caminhoArquivo;
        Status = MediaStatus.Pendente;
    }

    public string CaminhoArquivo { get; set; }
    public string? EncodingCaminho { get; set; }
    public MediaStatus Status { get; set; }
}
