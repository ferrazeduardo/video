using System;
using Catalogo.Application.Common;
using Catalogo.Application.Interface;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.UpdloadMedias;

public class UploadMedias : IRequestHandler<UploadMediasInput>
{
    private IVideoRespository _videoRepository;
    private IUnitOfWork _unitOfWork;
    private IStorageService _storageService;

    public UploadMedias(IVideoRespository videoRepository, IUnitOfWork unitOfWork, IStorageService storageService)
    {
        _videoRepository = videoRepository;
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }

    public async Task Handle(UploadMediasInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.id == request.idVideo, cancellationToken);
        NotFoundException.IsNull(video, $"Video com id {request.idVideo} não encontrado");
        await UploadVideo(request, video, cancellationToken);

        await UpdateTrailer(request, video, cancellationToken);

        await _videoRepository.Update(video, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

    }

    private async Task UpdateTrailer(UploadMediasInput request, Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (request.trailerInput is not null)
        {
            var fileName = StorageName.Create(video.id, nameof(video.Trailer), request.trailerInput.extension);
            var uploadedArquivo = await _storageService.Upload(fileName, request.trailerInput.arquivoStream, cancellationToken);
            video.UpdateTrailer(uploadedArquivo);
        }
    }

    private async Task UploadVideo(UploadMediasInput request, Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (request.arquivoVideo is not null)
        {
            var fileName = StorageName.Create(video.id, nameof(video.Media), request.arquivoVideo.extension);
            var uploadedArquivo = await _storageService.Upload(fileName, request.arquivoVideo.arquivoStream, cancellationToken);
            video.UpdateMedia(uploadedArquivo);
        }
    }
}
