using System;
using Catalogo.Application.Common;
using Catalogo.Application.Interface.SearchRepository;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.List;

public class ListCastFilmeInput : PaginetedListInput, IRequest<ListCastFilmeOutput>
{
    public ListCastFilmeInput(int pagina, int perPagina, string pesquisa, string ordernacao, SearchOrder order) : base(pagina, perPagina, pesquisa, ordernacao, order)
    {
    }
}
