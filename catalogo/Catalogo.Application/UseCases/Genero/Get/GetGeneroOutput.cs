using System;
using Catalogo.Application.UseCases.Genero.Common;

namespace Catalogo.Application.UseCases.Genero.Get;

public class GetGeneroOutput
{
    public GeneroModelOutput genero { get; set; } = new();

    internal GetGeneroOutput From(Domain.Entity.Genero genero)
    {
        this.genero.id = genero.idGuid;
        this.genero.nome = genero.Nome;
        return this;
    }
}
