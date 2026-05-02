using System;
using Catalogo.Domain.Enum;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Domain.Entity;

public class CastFilme : AggregationRoot
{
    public CastFilme(string nome, DateTime dataCriacao, CastFilmeTipo tipo) : base()
    {
        Nome = nome;
        DataCriacao = dataCriacao;
        Tipo = tipo;
        Validacao();
    }

    public void Validacao()
    {
        ExcecaoDeDominio.HaError(string.IsNullOrEmpty(Nome), "O nome é obrigatório.");
    }

    public void Update(string nome,CastFilmeTipo tipo )
    {
        Nome = nome is null ? Nome : nome;
        Tipo = tipo;
    }

    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public CastFilmeTipo Tipo { get; private set; }
}
