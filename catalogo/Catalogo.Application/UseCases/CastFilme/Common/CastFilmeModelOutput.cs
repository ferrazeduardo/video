using System;
using Catalogo.Domain.Enum;

namespace Catalogo.Application.UseCases.CastFilme.Common;

public class CastFilmeModelOutput
{

    public int id { get; set; }
    public string nome { get; set; }
    public CastFilmeTipo tipo { get; set; }
    public DateTime dataCriacao { get; set; }



}
