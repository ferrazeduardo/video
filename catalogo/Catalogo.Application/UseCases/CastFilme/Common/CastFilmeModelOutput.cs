using System;
using Catalogo.Domain.Enum;

namespace Catalogo.Application.UseCases.CastFilme.Common;

public class CastFilmeModelOutput
{
    public CastFilmeModelOutput(int id, string nome, CastFilmeTipo tipo, DateTime dataCriacao)
    {
        this.id = id;
        this.nome = nome;
        this.tipo = tipo;
        this.dataCriacao = dataCriacao;
    }

    public int id { get; set; }
    public string nome { get; set; }
    public CastFilmeTipo tipo { get; set; }
    public DateTime dataCriacao { get; set; }
}
