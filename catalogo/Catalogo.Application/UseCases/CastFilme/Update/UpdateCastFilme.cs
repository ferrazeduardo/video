using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Update;

public class UpdateCastFilme : IRequestHandler<UpdateCastFilmeInput, UpdateCastFilmeOutput>
{
    private ICastFilmeRepository _castFilmeRepository;
    private IUnitOfWork _unitOfWork;

    public UpdateCastFilme(ICastFilmeRepository castFilmeRepository, IUnitOfWork unitOfWork)
    {
        _castFilmeRepository = castFilmeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCastFilmeOutput> Handle(UpdateCastFilmeInput request, CancellationToken cancellationToken)
    {
        var cast = await _castFilmeRepository.Get(x => x.idGuid == request.id, cancellationToken);
        NotFoundException.IsNull(cast, "Cast não encontrado");

        cast.Update(request.nome, request.tipo);
        await _unitOfWork.Commit(cancellationToken);

        return new UpdateCastFilmeOutput();
    }
}
