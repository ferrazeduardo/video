using System;
using Catalogo.Application.Common;
using Catalogo.Application.UseCases.Genero.Common;

namespace Catalogo.Application.UseCases.Genero.List;

public class ListGeneroOutput : PaginetedListOutput<List<GeneroModelOutput>>
{
    public ListGeneroOutput(int pagina, int perPagina, int total, List<GeneroModelOutput> items) : base(pagina, perPagina, total, items)
    {
    }
}
