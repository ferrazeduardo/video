using System;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Categoria.Get;

public class GetCategoriaOutput
{
    public Guid id { get; set; }
    public string nome { get; set; }
    public string status { get; set; }

    public void FromCategoria(domain.Categoria categoria)
    {
        id = categoria.idGuid;
        nome = categoria.Nome;
        status = categoria.Status;
    }
}
