using System;
using Catalogo.Domain.Interface.Repository;
using Catalogo.Domain.Exceptions;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Get;

public class GetGenero : IRequestHandler<GetGeneroInput, GetGeneroOutput>
{
    private IGeneroRepository _generoRepository;

    public GetGenero(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }
    public async Task<GetGeneroOutput> Handle(GetGeneroInput request, CancellationToken cancellationToken)
    {
        var genero = await _generoRepository.Get(x => x.idGuid == request.id, cancellationToken, false);
        NotFoundException.Object(genero, "Genero não encontrado");

        return new GetGeneroOutput().From(genero);
    }
}
