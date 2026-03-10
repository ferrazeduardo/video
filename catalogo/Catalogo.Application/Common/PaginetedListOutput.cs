using System;

namespace Catalogo.Application.Common;

public abstract class PaginetedListOutput<TOutput>
{
    protected PaginetedListOutput(int pagina, int perPagina, int total, TOutput items)
    {
        this.pagina = pagina;
        this.perPagina = perPagina;
        this.total = total;
        Items = items;
    }

    public int pagina { get; set; }
    public int perPagina { get; set; }
    public int total { get; set; }

    public TOutput Items { get; set; }
}
