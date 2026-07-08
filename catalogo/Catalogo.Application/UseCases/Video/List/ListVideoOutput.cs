using System;
using Catalogo.Application.Common;
using Catalogo.Application.UseCases.Video.Common;

namespace Catalogo.Application.UseCases.Video.List;

public class ListVideoOutput : PaginetedListOutput<List<VideoModelOutput>>
{
    public ListVideoOutput(int pagina, int perPagina, int total, List<VideoModelOutput> items) : base(pagina, perPagina, total, items)
    {
    }
}
