using System;
using Catalogo.Application.Interface.Repository;
using Catalogo.Application.UseCases.Categoria.Common;
using Catalogo.Domain.Exceptions;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Get;

public class GetCategoria : IRequestHandler<GetCategoriaInput, GetCategoriaOutput<CategoriaModelOutput>>
{
    private ICategoriaRepository _categoriaRepository;

    public GetCategoria(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }
    public async Task<GetCategoriaOutput<CategoriaModelOutput>> Handle(GetCategoriaInput request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.Get(x => x.idGuid == request.id,cancellationToken);

        NotFoundException.Object(categoria, "Categoria não encontrada");

        GetCategoriaOutput<CategoriaModelOutput> getCategoriaOutput = new();
        getCategoriaOutput.Categoria.FromCategoria(categoria);

        return getCategoriaOutput;
    }
}
