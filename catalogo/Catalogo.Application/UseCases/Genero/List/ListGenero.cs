using System;
using Catalogo.Domain.Interface.Repository;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Application.UseCases.Genero.Common;
using MediatR;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Genero.List;

public class ListGenero : IRequestHandler<ListGeneroInput, ListGeneroOutput>
{
    private IGeneroRepository _generoRepository;

    public ListGenero(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }

    public async Task<ListGeneroOutput> Handle(ListGeneroInput request, CancellationToken cancellationToken)
    {
       var searchoutput = await _generoRepository.Search(new SearchInput(request.pagina, request.perPagina, request.pesquisa, request.ordernacao, request.order), cancellationToken);

        var output = new ListGeneroOutput(
            searchoutput.paginaAtual,
            searchoutput.Quantidade,
            searchoutput.Total,
            searchoutput.Itens.Select<domain.Genero, GeneroModelOutput>(i => new GeneroModelOutput().FromGeneroObject(i)).ToList()
        );

        return output;
    }
}
