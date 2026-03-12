using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interface.Repository;
using MediatR;
using domain = Catalogo.Domain.Entity;

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
        var categoria = new domain.Categoria();
        categoria.SetIdGuid(request.id);
        await _categoriaRepository.Delete(categoria, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new DeleteCategoriaOutput();
    }
}
