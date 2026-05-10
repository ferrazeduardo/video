using System;
using Catalogo.Application.UseCases.CastFilme.Common;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Get;

public class GetCastFilme : IRequestHandler<GetCastFilmeInput, GetCastFilmeOutput>
{
    private ICastFilmeRepository _castFilmeRepository;

    public GetCastFilme(ICastFilmeRepository castFilmeRepository)
    {
        _castFilmeRepository = castFilmeRepository;
    }

    public async Task<GetCastFilmeOutput> Handle(GetCastFilmeInput request, CancellationToken cancellationToken)
    {
        var cast = await _castFilmeRepository.Get(x => x.idGuid == request.id, cancellationToken, false);
        NotFoundException.IsNull(cast, "CastFilme não encontrado");
        var output = new GetCastFilmeOutput();
        output.From(cast);
        return output;
    }
}
