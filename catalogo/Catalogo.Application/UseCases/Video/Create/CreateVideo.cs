using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Interface.Repository;
using MediatR;
using AppDomain = Catalogo.Domain.Entity;
namespace Catalogo.Application.UseCases.Video.Create;

public class CreateVideo : IRequestHandler<CreateVideoInput, CreateVideoOutput>
{
    private IVideoRespository _videoRespository;
    private IUnitOfWork _unitOfWork;

    public CreateVideo(IVideoRespository videoRespository, IUnitOfWork unitOfWork)
    {
        _videoRespository = videoRespository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateVideoOutput> Handle(CreateVideoInput request, CancellationToken cancellationToken)
    {
        var video = new AppDomain.Video(request.titulo, request.descricao, request.publicado, request.duracao, request.anoLancamento, request.rating);

        await _videoRespository.Insert(video, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        return new CreateVideoOutput(video.idGuid);
    }
}
