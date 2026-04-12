using System;
using Catalogo.Application.Interface.Repository;
using Catalogo.Domain.Exceptions;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.AddCategoria;

public class AddCategoria : IRequestHandler<AddCategoriaInput, AddCategoriaOutput>
{
    private IGeneroRepository _repository;

    public AddCategoria(IGeneroRepository repository)
    {
        _repository = repository;
    }
    public async Task<AddCategoriaOutput> Handle(AddCategoriaInput request, CancellationToken cancellationToken)
    {
        var genero = await _repository.Get(x => x.idGuid == request.Id, cancellationToken);

        NotFoundException.Object(genero, "Genero não encontrado");

        genero.AddCategoria(request.Id, request.Nome);

        return new AddCategoriaOutput();
    }
}
