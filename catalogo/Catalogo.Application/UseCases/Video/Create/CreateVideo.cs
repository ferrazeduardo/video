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

        await _videoRespository.Insert(video, cancellationToken);

        if (request.thumb is not null)
        {
            var thumbUrl = await _storageService.Upload($"{video.id}-thumb.{request.thumb.extension}", request.thumb.arquivoStream, cancellationToken);
            video.UpdateThumb(thumbUrl);
        }

        if (request.banner is not null)
        {
            var url = await _storageService.Upload($"{video.id}-banner.{request.banner.extension}", request.banner.arquivoStream, cancellationToken);
            video.UpdateBanner(url);
        }

        if (request.thumbHalf is not null)
        {
            var url = await _storageService.Upload($"{video.id}-banner.{request.thumbHalf.extension}", request.thumbHalf.arquivoStream, cancellationToken);
            video.UpdateThumbHald(url);
        }

        await _unitOfWork.Commit(cancellationToken);

        return new CreateVideoOutput(video.idGuid);
    }
}
