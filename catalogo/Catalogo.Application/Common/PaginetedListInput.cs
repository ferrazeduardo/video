using System;
using Catalogo.Application.Interface.SearchRepository;

namespace Catalogo.Application.Common;

public abstract class PaginetedListInput
{
    public int pagina { get; set; }
    public int perPagina { get; set; }
    public string pesquisa { get; set; }
    public string ordernacao { get; set; }
    public SearchOrder order { get; set; }

    public PaginetedListInput(int pagina, int perPagina,string pesquisa, string ordernacao, SearchOrder order)
    {
        this.pagina = pagina;
        this.perPagina = perPagina;
        this.pesquisa = pesquisa;
        this.ordernacao = ordernacao;
        this.order = order;
    }

}
