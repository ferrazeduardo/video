using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interface.Repository;
using Catalogo.Domain.Exceptions;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Update;

public class UpdateCategoria : IRequestHandler<UpdateCategoriaInput, UpdateCategoriaOutput>
{
    private ICategoriaRepository _categoriaRepository;
    private IUnitOfWork _unitOfWork;

    public UpdateCategoria(ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
    {
        _categoriaRepository = categoriaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCategoriaOutput> Handle(UpdateCategoriaInput request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.Get(request.id);

        NotFoundException.Object(categoria, "Categoria não encontrada");

        categoria.Update(request.nome,request.descricao,request.status);

        await _categoriaRepository.Update(categoria,cancellationToken);

        return new UpdateCategoriaOutput();
    }
}
