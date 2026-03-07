using System;
using Catalogo.Application.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Get;

public class GetCategoria : IRequestHandler<GetCategoriaInput, GetCategoriaOutput>
{
    private ICategoriaRepository _categoriaRepository;

    public GetCategoria(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }
    public async Task<GetCategoriaOutput> Handle(GetCategoriaInput request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.Get(request.id);

        GetCategoriaOutput getCategoriaOutput = new();
        getCategoriaOutput.FromCategoria(categoria);

        return getCategoriaOutput;
    }
}
