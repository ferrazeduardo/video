using System;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Application.Interface.SearchRepository;

public class SearchOutput<T> where T : AggregationRoot
{
    public SearchOutput(int paginaAtual, int quantidade, int total, IReadOnlyList<T> itens)
    {
        this.paginaAtual = paginaAtual;
        Quantidade = quantidade;
        Total = total;
        Itens = itens;
    }

    public int paginaAtual { get; set; }
    public int Quantidade { get; set; }
    public int Total { get; set; }
    public IReadOnlyList<T> Itens { get; set; }
}
