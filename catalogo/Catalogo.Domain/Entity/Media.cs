using System;
using Catalogo.Domain.Enum;

namespace Catalogo.Domain.Entity;

public class Media  : SeedWork.Entity
{
    public Media(string caminhoArquivo)
    {
        CaminhoArquivo = caminhoArquivo;
        Status = MediaStatus.Pendente;
    }

    public string CaminhoArquivo { get; private set; }
    public string? EncodingCaminho { get; private set; }
    public MediaStatus Status { get; set; }

    public void UpdateProcessando()
    {
        Status = MediaStatus.Processando;
    }

    public void UpdateProcessado(string encodingCaminho)
    {
        Status = MediaStatus.Processado;
        EncodingCaminho = encodingCaminho;
    }
}
