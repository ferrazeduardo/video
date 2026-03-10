using System;
using Catalogo.Application.Common;
using Catalogo.Application.UseCases.Categoria.Common;
using Catalogo.Application.UseCases.Categoria.Get;

namespace Catalogo.Application.UseCases.Categoria.List;

public class ListCategoriaOutput : PaginetedListOutput<List<CategoriaModelOutput>>
{
    public ListCategoriaOutput(int pagina, int perPagina, int total, List<CategoriaModelOutput> items) : base(pagina, perPagina, total, items)
    {
    }
}
