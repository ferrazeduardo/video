using System;
using Catalogo.Application.UseCases.Video.Common;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Get;

public class GetVideo : IRequestHandler<GetVideoInput, GetVideoOutput>
{
    private IVideoRespository _videoRepository;

    public GetVideo(IVideoRespository videoRepository)
    {
        _videoRepository = videoRepository;
    }
    public async Task<GetVideoOutput> Handle(GetVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.idGuid == request.id, cancellationToken, false);
        NotFoundException.IsNull(video, "Video não encontrado");   

        VideoModelOutput videoModelOutput = new VideoModelOutput(video.idGuid, video.Titulo, video.Descricao, video.AnoLancamento, video.Duracao, video.Thumb?.caminho, video.banner?.caminho, video.Media?.CaminhoArquivo, video.ThumbHalf?.caminho, video.Trailer?.CaminhoArquivo);
        GetVideoOutput output = new GetVideoOutput();
        output.video = videoModelOutput;
        return output;
    }
}
