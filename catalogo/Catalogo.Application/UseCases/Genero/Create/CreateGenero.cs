using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interface.Repository;
using MediatR;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Genero.Create;

public class CreateGenero : IRequestHandler<CreateGeneroInput, CreateGeneroOutput>
{
    private IGeneroRepository _generoRepositor;
    private IUnitOfWork _unistOfWork;

    public CreateGenero(IGeneroRepository generoRepositor, IUnitOfWork unistOfWork)
    {
        _generoRepositor = generoRepositor;
        _unistOfWork = unistOfWork;
    }
    public async Task<CreateGeneroOutput> Handle(CreateGeneroInput request, CancellationToken cancellationToken)
    {
        var genero = new domain.Genero(request.nome);
        await _generoRepositor.Insert(genero, cancellationToken);
        await _unistOfWork.Commit(cancellationToken);

        return new CreateGeneroOutput()
        {
            id = genero.idGuid
        };
    }
}
