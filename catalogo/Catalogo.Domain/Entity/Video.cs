using System;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Domain.Entity;

public class Video : AggregationRoot
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }

    public DateTime DataCriacao { get; private set; }
}
