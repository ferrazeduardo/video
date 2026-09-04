using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Interface.Repository;
using Catalogo.Domain.Exceptions;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Delete;

public class DeleteCategoria : IRequestHandler<DeleteCategoriaInput, DeleteCategoriaOutput>
{
    private IUnitOfWork _unitOfWork;
    private ICategoriaRepository _categoriaRepository;

    public DeleteCategoria(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _categoriaRepository = categoriaRepository;
    }

    public async Task<DeleteCategoriaOutput> Handle(DeleteCategoriaInput request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.Get(x => x.id == request.id, cancellationToken);

        NotFoundException.IsNull(categoria, "Categoria não encontrada");

        await _categoriaRepository.Delete(categoria, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new DeleteCategoriaOutput();
    }
}
