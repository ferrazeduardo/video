using System;
using Catalogo.Application.UseCases.Categoria.Common;

namespace Catalogo.Application.UseCases.Genero.Common;

public class GeneroModelOutput
{
    public Guid id { get; set; }
    public string nome { get; set; }
    public string status { get; set; }



    public void FromGenero(Domain.Entity.Genero genero)
    {
        id = genero.idGuid;
        nome = genero.Nome;
        status = genero.Status.ToString();
    }

    public GeneroModelOutput FromGeneroObject(Domain.Entity.Genero i)
    {
        FromGenero(i);
        return this;
    }
}
