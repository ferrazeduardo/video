using Catalogo.Application.Common;
using Catalogo.Application.Interface.SearchRepository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.List;

public class ListVideoInput : PaginetedListInput, IRequest<ListVideoOutput>
{
    public ListVideoInput(int pagina, int perPagina, string pesquisa, string ordernacao, SearchOrder order) : base(pagina, perPagina, pesquisa, ordernacao, order)
    {
    }
}
