using System;

namespace Catalogo.Domain.ValueObject;

public class Image : SeedWork.ValueObject
{
    public string caminho { get; }

    public Image(string caminho)
    {
        this.caminho = caminho;
    }

    public override bool Equals(SeedWork.ValueObject? other)
    {
        return other is Image image && caminho == image.caminho;
    }
}
