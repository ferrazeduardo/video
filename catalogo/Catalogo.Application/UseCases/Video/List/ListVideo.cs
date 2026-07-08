using System;
using Catalogo.Application.UseCases.Video.Common;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.List;

public class ListVideo : IRequestHandler<ListVideoInput, ListVideoOutput>
{
    private IVideoRespository _videoRespository;

    public ListVideo(IVideoRespository videoRespository)
    {
        _videoRespository = videoRespository;
    }

    public async Task<ListVideoOutput> Handle(ListVideoInput request, CancellationToken cancellationToken)
    {
        var result = await _videoRespository.Search(new Interface.SearchRepository.SearchInput(
            request.pagina,
            request.perPagina,
            request.pesquisa,
            request.ordernacao,
            request.order
        ),cancellationToken);

        var output = new ListVideoOutput(
            result.paginaAtual,
            result.Quantidade,
            result.Total,
            result.Itens.Select<Domain.Entity.Video, VideoModelOutput>(i => new VideoModelOutput(i.idGuid,i.Titulo,i.Descricao,i.AnoLancamento,i.Duracao,i.Thumb.caminho,i.banner.caminho,i.Media.CaminhoArquivo,i.ThumbHalf.caminho,i.Trailer.CaminhoArquivo)).ToList()
        );

        return output;
    }
}
