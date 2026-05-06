using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Interface.Repository;
using MediatR;
using AppDomain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.CastFilme.Create;

public class CreateCastFilme : IRequestHandler<CreateCastFilmeInput, CreateCastFilmeOutput>
{
    private ICastFilmeRepository _castFilmeRepository;
    private IUnitOfWork _unitOfWork;

    public CreateCastFilme(ICastFilmeRepository castFilmeRepository, IUnitOfWork unitOfWork)
    {
        _castFilmeRepository = castFilmeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCastFilmeOutput> Handle(CreateCastFilmeInput request, CancellationToken cancellationToken)
    {
        var cast = new AppDomain.CastFilme(request.nome, DateTime.Now, request.tipo);
        await _castFilmeRepository.Insert(cast, cancellationToken);
        await _unitOfWork.Commit( cancellationToken);

        return new CreateCastFilmeOutput(cast.idGuid);
    }
}
