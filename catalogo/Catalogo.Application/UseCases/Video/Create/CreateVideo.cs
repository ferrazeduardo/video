using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Interface.Repository;
using MediatR;
using AppDomain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Video.Create;

public class CreateVideo : IRequestHandler<CreateVideoInput, CreateVideoOutput>
{
    private IVideoRespository _videoRespository;
    private IUnitOfWork _unitOfWork;
    private IStorageService _storageService;

    public CreateVideo(IVideoRespository videoRespository, IUnitOfWork unitOfWork, IStorageService storageService)
    {
        _videoRespository = videoRespository;
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }
    public async Task<CreateVideoOutput> Handle(CreateVideoInput request, CancellationToken cancellationToken)
    {
        var video = new AppDomain.Video(request.titulo, request.descricao, request.publicado, request.duracao, request.anoLancamento, request.rating);


        try
        {
            await UploadThung(request, video, cancellationToken);
            await UploadBanner(request, video, cancellationToken);
            await UploadThumbHalf(request, video, cancellationToken);
            await _videoRespository.Insert(video, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

        }
        catch (Exception ex)
        {
            await DeleteThumb(video, cancellationToken);
            await DeleteBanner(video, cancellationToken);
            await DeleteThumbHalf(video, cancellationToken);

            throw new ApplicationException($"Erro ao salvar o video {request.descricao}", ex);
        }


        return new CreateVideoOutput(video.idGuid);
    }

    private async Task DeleteThumbHalf(AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (video.ThumbHalf is not null) await _storageService.Delete(video.ThumbHalf.caminho, cancellationToken);
    }

    private async Task DeleteBanner(AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (video.banner is not null) await _storageService.Delete(video.banner.caminho, cancellationToken);
    }

    private async Task DeleteThumb(AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (video.Thumb is not null) await _storageService.Delete(video.Thumb.caminho, cancellationToken);
    }

    private async Task UploadThumbHalf(CreateVideoInput request, AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (request.thumbHalf is not null)
        {
            var url = await _storageService.Upload($"{video.id}-thumbHanlf.{request.thumbHalf.extension}", request.thumbHalf.arquivoStream, cancellationToken);
            video.UpdateThumbHald(url);
        }
    }

    private async Task UploadBanner(CreateVideoInput request, AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (request.banner is not null)
        {
            var url = await _storageService.Upload($"{video.id}-banner.{request.banner.extension}", request.banner.arquivoStream, cancellationToken);
            video.UpdateBanner(url);
        }
    }

    private async Task UploadThung(CreateVideoInput request, AppDomain.Video video, CancellationToken cancellationToken)
    {
        if (request.thumb is not null)
        {
            var thumbUrl = await _storageService.Upload($"{video.id}-thumb.{request.thumb.extension}", request.thumb.arquivoStream, cancellationToken);
            video.UpdateThumb(thumbUrl);
        }
    }
}
