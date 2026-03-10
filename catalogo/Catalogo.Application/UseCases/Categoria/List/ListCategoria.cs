using System;
using Catalogo.Application.Interface.Repository;
using Catalogo.Application.Interface.SearchRepository;
using Catalogo.Application.UseCases.Categoria.Common;
using MediatR;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Categoria.List;

public class ListCategoria : IRequestHandler<ListCategoriaInput, ListCategoriaOutput>
{
    private ICategoriaRepository _categoriaRepository;

    public ListCategoria(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<ListCategoriaOutput> Handle(ListCategoriaInput request, CancellationToken cancellationToken)
    {
        var searchOutpu = await _categoriaRepository.Search(new SearchInput(request.pagina, request.perPagina, request.pesquisa, request.ordernacao, request.order), cancellationToken);


        var output = new ListCategoriaOutput(
            searchOutpu.paginaAtual,
            searchOutpu.PerPagina,
            searchOutpu.Total,
            searchOutpu.Itens.Select<domain.Categoria,CategoriaModelOutput>(i => new CategoriaModelOutput().FromCategoriaObject(i)).ToList()
        );

        return output;
    }
}
