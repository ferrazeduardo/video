using System;
using Catalogo.Application.Common;
using Catalogo.Application.Interface.SearchRepository;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.List;

public class ListGeneroInput : PaginetedListInput, IRequest<ListGeneroOutput>
{
    public ListGeneroInput(int pagina, int perPagina, string pesquisa, string ordernacao, SearchOrder order) : base(pagina, perPagina, pesquisa, ordernacao, order)
    {
    }
}
