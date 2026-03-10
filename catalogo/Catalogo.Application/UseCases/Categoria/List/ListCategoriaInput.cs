using System;
using Catalogo.Application.Common;
using Catalogo.Application.Interface.SearchRepository;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.List;

public class ListCategoriaInput : PaginetedListInput, IRequest<ListCategoriaOutput>
{
    public ListCategoriaInput(int pagina, int perPagina, string pesquisa, string ordernacao, SearchOrder order) : base(pagina, perPagina, pesquisa, ordernacao, order)
    {
    }
}
