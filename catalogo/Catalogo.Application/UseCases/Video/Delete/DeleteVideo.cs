using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Delete;

public class DeleteVideo : IRequestHandler<DeleteVideoInput, DeleteVideoOutput>
{
    private IUnitOfWork _unitOfWork;
    private IVideoRespository _videoRepository;
    private IStorageService _storageService;

    public DeleteVideo(IUnitOfWork unitOfWork, IVideoRespository videoRepository, IStorageService storageService)
    {
        _unitOfWork = unitOfWork;
        _videoRepository = videoRepository;
        _storageService = storageService;
    }

    public async Task<DeleteVideoOutput> Handle(DeleteVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.id == request.id, cancellationToken);
        NotFoundException.IsNull(video, "Video não encontrado");

        await _videoRepository.Delete(video, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        await DeleteThumb(video, cancellationToken);
        await DeleteBanner(video, cancellationToken);
        await DeleteThumbHalf(video, cancellationToken);
        await DeleteMedia(video, cancellationToken);
        await DeleteTrailer(video, cancellationToken);

        return new DeleteVideoOutput();
    }

    private async Task DeleteTrailer(Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (video.Trailer is not null) await _storageService.Delete(video.Trailer.CaminhoArquivo, cancellationToken);
    }

    private async Task DeleteMedia(Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (video.Media is not null) await _storageService.Delete(video.Media.CaminhoArquivo, cancellationToken);
    }

    private async Task DeleteThumbHalf(Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (video.ThumbHalf is not null) await _storageService.Delete(video.ThumbHalf.caminho, cancellationToken);
    }

    private async Task DeleteBanner(Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (video.banner is not null) await _storageService.Delete(video.banner.caminho, cancellationToken);
    }

    private async Task DeleteThumb(Domain.Entity.Video video, CancellationToken cancellationToken)
    {
        if (video.Thumb is not null) await _storageService.Delete(video.Thumb.caminho, cancellationToken);
    }
}
