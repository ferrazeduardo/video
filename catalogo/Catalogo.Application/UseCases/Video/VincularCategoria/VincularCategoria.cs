using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.VincularCategoria;

public class VincularCategoria : IRequestHandler<VincularCategoriaInput, VincularCategoriaOuput>
{
    private IUnitOfWork _unitOfWork;
    private ICategoriaRepository _categoriaRepository;
    private IVideoRespository _videoRespository;

    public VincularCategoria(IVideoRespository videoRespository, ICategoriaRepository categoriaRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _categoriaRepository = categoriaRepository;
        _videoRespository = videoRespository;
    }

    public async Task<VincularCategoriaOuput> Handle(VincularCategoriaInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRespository.Get(x => x.idGuid == request.idVideo, cancellationToken);
        var categoria = await _categoriaRepository.Get(x => x.idGuid == request.idCategoria, cancellationToken);

        NotFoundException.IsNull(video, "Video não existe");
        NotFoundException.IsNull(categoria, "Categoria não existe");

        video.AddCategoria(categoria.id, categoria.idGuid);

        await _unitOfWork.Commit(cancellationToken);

        return new VincularCategoriaOuput();
    }
}
