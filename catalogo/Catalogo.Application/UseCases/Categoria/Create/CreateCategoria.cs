using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Interface.Repository;
using MediatR;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Categoria.Create;

public class CreateCategoria : IRequestHandler<CreateCategoriaInput,CreateCategoriaOutput>
{
    private IUnitOfWork _unitOfWork;
    private ICategoriaRepository _categoriaRepository;

    public CreateCategoria(IUnitOfWork unitOfWork, ICategoriaRepository categoriaRepository)
    {
        _unitOfWork = unitOfWork;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<CreateCategoriaOutput> Handle(CreateCategoriaInput request, CancellationToken cancellationToken)
    {
         var categoria = new domain.Categoria(request.nome, request.descricao);

        await _categoriaRepository.Insert(categoria, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        CreateCategoriaOutput createCategoriaOutput = new();
        createCategoriaOutput.id = categoria.idGuid;

        return createCategoriaOutput;
    }
}
