using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddCategoria;

public class VincularCategoria : IRequestHandler<AddCategoriaInput, AddCategoriaOuput>
{
    private IUnitOfWork _unitOfWork;
    private ICategoriaRepository _categoriaRepository;
    private IVideoRespository _videoRespository;
    private IVideoCategoriaRepository _videoCategoriaRepository;

    public VincularCategoria(
        IVideoRespository videoRespository,
        ICategoriaRepository categoriaRepository,
        IUnitOfWork unitOfWork,
        IVideoCategoriaRepository videoCategoriaRepository)
    {
        _unitOfWork = unitOfWork;
        _categoriaRepository = categoriaRepository;
        _videoRespository = videoRespository;
        _videoCategoriaRepository = videoCategoriaRepository;
    }

    public async Task<AddCategoriaOuput> Handle(AddCategoriaInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRespository.Get(x => x.idGuid == request.idVideo, cancellationToken);
        var categoria = await _categoriaRepository.Get(x => x.idGuid == request.idCategoria, cancellationToken);

        NotFoundException.IsNull(video, "Video não existe");
        NotFoundException.IsNull(categoria, "Categoria não existe");

        var videoCategoria = new VideoCategoria(video.id, categoria.id);

        await _videoCategoriaRepository.Create(videoCategoria, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new AddCategoriaOuput();
    }
}
