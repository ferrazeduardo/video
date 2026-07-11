using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Update;

public class UpdateVideo : IRequestHandler<UpdateVideoInput, UpdateVideoOutput>
{
    private IVideoRespository _videoRepository;
    private IUnitOfWork _unitOfWork;

    public UpdateVideo(IVideoRespository videoRepository, IUnitOfWork unitOfWork)
    {
        _videoRepository = videoRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<UpdateVideoOutput> Handle(UpdateVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.idGuid == request.id, cancellationToken);
        NotFoundException.IsNull(video, "Video não encontrado");

        video.Update(request.titulo, request.descricao, request.anoLancamento, request.duracao, request.publicado, request.rating);
        await _unitOfWork.Commit(cancellationToken);

        return new UpdateVideoOutput();
    }
}
