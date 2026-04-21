using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Delete;

public class DeleteGenero : IRequestHandler<DeleteGeneroInput, DeleteGeneroOutput>
{
    private IGeneroRepository _generoRepository;
    private IUnitOfWork _unitOfWork;

    public DeleteGenero(IGeneroRepository generoRepository, IUnitOfWork unitOfWork)
    {
        _generoRepository = generoRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<DeleteGeneroOutput> Handle(DeleteGeneroInput request, CancellationToken cancellationToken)
    {
        var genero = new Catalogo.Domain.Entity.Genero();
        genero.SetIdGuid(request.id);
        await _generoRepository.Delete(genero, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        return new DeleteGeneroOutput();
    }
}
