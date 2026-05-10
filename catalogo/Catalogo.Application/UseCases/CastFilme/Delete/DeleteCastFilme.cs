using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Delete;

public class DeleteCastFilme : IRequestHandler<DeleteCastFilmeInput, DeleteCastFilmeOutput>
{
    private ICastFilmeRepository _castFilmeRepository;
    private IUnitOfWork _unitOfWork;

    public DeleteCastFilme(ICastFilmeRepository castFilmeRepository, IUnitOfWork unitOfWork)
    {
        _castFilmeRepository = castFilmeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteCastFilmeOutput> Handle(DeleteCastFilmeInput request, CancellationToken cancellationToken)
    {
        var cast = await _castFilmeRepository.Get(x => x.idGuid == request.Id, cancellationToken, true);
        NotFoundException.IsNull(cast, "CastFilme não encontrado");
        await _castFilmeRepository.Delete(cast, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        return new DeleteCastFilmeOutput();
    }
}
