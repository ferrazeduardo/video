using System;
using Catalogo.Application.Common;
using Catalogo.Application.Interface;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Exceptions;
using AppDomain = Catalogo.Domain.Entity;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Update;

public class UpdateVideo : IRequestHandler<UpdateVideoInput, UpdateVideoOutput>
{
    private IVideoRespository _videoRepository;
    private IUnitOfWork _unitOfWork;
    private IStorageService _storageService;

    public UpdateVideo(
     IVideoRespository videoRepository,
     IUnitOfWork unitOfWork,
     IStorageService storageService)
    {
        _videoRepository = videoRepository;
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }
    public async Task<UpdateVideoOutput> Handle(UpdateVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.idGuid == request.id, cancellationToken);
        NotFoundException.IsNull(video, "Video não encontrado");

        video.Update(request.titulo, request.descricao, request.anoLancamento, request.duracao, request.publicado, request.rating);
        await UploadImageBanner(request,video,cancellationToken);
        await UploadImageThumb(request,video,cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new UpdateVideoOutput();
    }

    private async Task UploadImageBanner(UpdateVideoInput request, AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (request.banner is null) return;

        var arquivoNome = StorageName.Create(video.id, nameof(video.banner), request.banner.extension);
        var bannerUrl = await _storageService.Upload(arquivoNome, request.banner.arquivoStream, cancellationToken);
        video.UpdateBanner(bannerUrl);
    }
    private async Task UploadImageThumb(UpdateVideoInput request, AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (request.thumb is null) return;

        var arquivoNome = StorageName.Create(video.id, nameof(video.Thumb), request.thumb.extension);
        var thumbUrl = await _storageService.Upload(arquivoNome, request.thumb.arquivoStream, cancellationToken);
        video.UpdateBanner(thumbUrl);
    }
}
