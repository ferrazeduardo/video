using System;
using Catalogo.Application.UseCases.Categoria.Common;

namespace Catalogo.Application.UseCases.Genero.Common;

public class GeneroModelOutput
{
    public Guid id { get; set; }
    public string nome { get; set; }
    public string status { get; set; }

    public List<CategoriaModelOutput> categorias { get; set; }
}
