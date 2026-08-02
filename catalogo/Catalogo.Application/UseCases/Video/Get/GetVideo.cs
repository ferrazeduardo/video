using System;
using Catalogo.Application.UseCases.Video.Common;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Get;

public class GetVideo : IRequestHandler<GetVideoInput, GetVideoOutput>
{
    private IVideoRespository _videoRepository;
    private ICategoriaRepository _categoriaRepository;
    private IGeneroRepository _generoRepository;
    private ICastFilmeRepository _castFilmeRepository;

    public GetVideo(IVideoRespository videoRepository,
        ICategoriaRepository categoriaRepository,
        IGeneroRepository generoRepository,
        ICastFilmeRepository castFilmeRepository)
    {
        _videoRepository = videoRepository;
        _categoriaRepository = categoriaRepository;
        _generoRepository = generoRepository;
        _castFilmeRepository = castFilmeRepository;
    }
    public async Task<GetVideoOutput> Handle(GetVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.idGuid == request.id, cancellationToken, false);
        NotFoundException.IsNull(video, "Video não encontrado");

        List<Catalogo.Domain.Entity.Categoria>? categorias = null;
        if (video.Categorias.Any())
            categorias = await _categoriaRepository.ListPorIds(video.Categorias.ToList(), cancellationToken);

        List<Catalogo.Domain.Entity.Genero>? generos = null;
        if (video.Generos.Any())
            generos = await _generoRepository.ListPorIds(video.Generos.ToList(), cancellationToken);

        List<Catalogo.Domain.Entity.CastFilme>? cast = null;
        if (video.CastsFilme.Any())
            cast = await _castFilmeRepository.ListPorIds(video.CastsFilme.ToList(), cancellationToken);

        VideoModelOutput videoModelOutput = new VideoModelOutput(
            video.idGuid,
            video.Titulo,
            video.Descricao,
            video.AnoLancamento,
            video.Duracao,
            categorias?.Select(c => new RelatedAgreggation(c.idGuid, c.Nome)).ToList(),
            generos?.Select(g => new RelatedAgreggation(g.idGuid, g.Nome)).ToList(),
            cast?.Select(c => new RelatedAgreggation(c.idGuid, c.Nome)).ToList(),
            video.Thumb?.caminho,
            video.banner?.caminho,
            video.Media?.CaminhoArquivo,
            video.ThumbHalf?.caminho,
            video.Trailer?.CaminhoArquivo);
        GetVideoOutput output = new GetVideoOutput();
        output.video = videoModelOutput;
        return output;
    }
}
