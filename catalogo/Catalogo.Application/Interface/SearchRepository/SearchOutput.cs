using System;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Application.Interface.SearchRepository;

public class SearchOutput<T> where T : AggregationRoot
{
    public SearchOutput(int paginaAtual, int perPagina, int total, IReadOnlyList<T> itens)
    {
        this.paginaAtual = paginaAtual;
        PerPagina = perPagina;
        Total = total;
        Itens = itens;
    }

    public int paginaAtual { get; set; }
    public int PerPagina { get; set; }
    public int Total { get; set; }
    public IReadOnlyList<T> Itens { get; set; }
}
