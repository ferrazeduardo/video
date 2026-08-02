using System;
using Catalogo.Application.UseCases.CastFilme.Common;

namespace Catalogo.Application.UseCases.CastFilme.Get;

public class GetCastFilmeOutput
{
    public CastFilmeModelOutput cast { get; set; }

    public void From(Catalogo.Domain.Entity.CastFilme castFilme)
    {
        cast = new CastFilmeModelOutput
        {
            id = castFilme.id,
            nome = castFilme.Nome,
            tipo = castFilme.Tipo,
            dataCriacao = castFilme.DataCriacao
        };
    }
}
