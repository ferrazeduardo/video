using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interface.Repository;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Categoria.Create;

public class CreateCategoria
{
    private IUnitOfWork _unitOfWork;
    private ICategoriaRepository _categoriaRepository;

    public CreateCategoria(IUnitOfWork unitOfWork, ICategoriaRepository categoriaRepository)
    {
        _unitOfWork = unitOfWork;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<CreateCategoriaOutput> Handler(CreateCategoriaInput createCategoriaInput, CancellationToken cancellationToken)
    {
        var categoria = new domain.Categoria(createCategoriaInput.nome, createCategoriaInput.descricao);

        await _categoriaRepository.Insert(categoria, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        CreateCategoriaOutput createCategoriaOutput = new();
        createCategoriaOutput.id = categoria.idGuid;

        return createCategoriaOutput;
    }
}
