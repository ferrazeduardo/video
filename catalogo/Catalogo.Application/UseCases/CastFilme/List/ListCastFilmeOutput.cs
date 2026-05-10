using System;
using Catalogo.Application.Common;
using Catalogo.Application.UseCases.CastFilme.Common;

namespace Catalogo.Application.UseCases.CastFilme.List;

public class ListCastFilmeOutput : PaginetedListOutput<List<CastFilmeModelOutput>>
{
    public ListCastFilmeOutput(int pagina, int perPagina, int total, List<CastFilmeModelOutput> items) : base(pagina, perPagina, total, items)
    {
    }
}
