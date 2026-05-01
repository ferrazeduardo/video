using System;
using Catalogo.Domain.Interface.Repository;
using Catalogo.Domain.Exceptions;
using MediatR;
using Catalogo.Domain.Entity;
using Catalogo.Application.Interface;

namespace Catalogo.Application.UseCases.Genero.AddCategoria;

public class AddCategoria : IRequestHandler<AddCategoriaInput, AddCategoriaOutput>
{
    private IGeneroRepository _repository;
    private ICategoriaRepository _categoriaRepository;
    private IUnitOfWork _unitOfWork;
    private IGeneroCategoriaRepository _generoCategoriaRepository;

    public AddCategoria(
        IGeneroRepository repository,
        ICategoriaRepository categoriaRepository,
        IUnitOfWork unitOfWork,
        IGeneroCategoriaRepository generoCategoriaRepository)
    {
        _repository = repository;
        _categoriaRepository = categoriaRepository;
        _unitOfWork = unitOfWork;
        _generoCategoriaRepository = generoCategoriaRepository;
    }
    public async Task<AddCategoriaOutput> Handle(AddCategoriaInput request, CancellationToken cancellationToken)
    {
        var genero = await _repository.Get(x => x.idGuid == request.Id, cancellationToken);
        var categoria = await _categoriaRepository.Get(x => x.idGuid == request.Id, cancellationToken);
        NotFoundException.IsNull(genero, "Genero não encontrado");
        NotFoundException.IsNull(categoria, "Categoria não encontrada");

        GenerosCategorias generosCategorias = new GenerosCategorias(genero.id, categoria.id);

        await _generoCategoriaRepository.Create(generosCategorias, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        return new AddCategoriaOutput();
    }
}
