using System;

namespace Catalogo.Application.Interface.SearchRepository;

public class SearchInput
{
    public SearchInput(int pagina, int perPagina, string pesquisa, string ordernacao, SearchOrder order)
    {
        Pagina = pagina;
        PerPagina = perPagina;
        Pesquisa = pesquisa;
        Ordernacao = ordernacao;
        Order = order;
    }

    public int Pagina { get; set; }
    public int PerPagina { get; set; }
    public string Pesquisa { get; set; }
    public string Ordernacao { get; set; }
    public SearchOrder Order { get; set; }
}
