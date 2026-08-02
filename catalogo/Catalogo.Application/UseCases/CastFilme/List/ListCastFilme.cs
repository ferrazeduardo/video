using System;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Application.UseCases.CastFilme.Common;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.List;

public class ListCastFilme : IRequestHandler<ListCastFilmeInput, ListCastFilmeOutput>
{
    private ICastFilmeRepository _repository;

    public ListCastFilme(ICastFilmeRepository repository)
    {
        _repository = repository;
    }
    public async Task<ListCastFilmeOutput> Handle(ListCastFilmeInput request, CancellationToken cancellationToken)
    {
        var searchOutpu = await _repository.Search(new SearchInput(request.pagina, request.perPagina, request.pesquisa, request.ordernacao, request.order), cancellationToken);

        return new ListCastFilmeOutput(
            searchOutpu.paginaAtual,
            searchOutpu.Quantidade,
            searchOutpu.Total,
            searchOutpu.Itens.Select(i => new CastFilmeModelOutput()
            {
                id = i.id,
                nome = i.Nome,
                tipo = i.Tipo,
                dataCriacao = i.DataCriacao
            }).ToList()
        );
    }
}
