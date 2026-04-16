using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interface.Repository;
using Catalogo.Domain.Exceptions;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Update;

public class UpdateGenero : IRequestHandler<UpdateGeneroInput, UpdateGeneroOutput>
{
    private ICategoriaRepository _categoriaRepository;
    private IUnitOfWork _unitOfWork;
    private IGeneroRepository _generoRepository;

    public UpdateGenero(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork, IGeneroRepository generoRepository)
    {
        _categoriaRepository = categoriaRepository;
        _unitOfWork = unitOfWork;
        _generoRepository = generoRepository;
    }
    public async Task<UpdateGeneroOutput> Handle(UpdateGeneroInput request, CancellationToken cancellationToken)
    {
        var genero = await _generoRepository.Get(x => x.idGuid == request.id, cancellationToken);
        NotFoundException.Object(genero, "Gênero não encontrado.");

        genero.Update(request.nome, request.status);

        await _unitOfWork.Commit(cancellationToken);

        return new UpdateGeneroOutput();
    }
}
