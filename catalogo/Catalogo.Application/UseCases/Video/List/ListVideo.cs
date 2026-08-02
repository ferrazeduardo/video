using System;
using Catalogo.Application.UseCases.Video.Common;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.List;

public class ListVideo : IRequestHandler<ListVideoInput, ListVideoOutput>
{
    private IVideoRespository _videoRespository;
    private ICategoriaRepository _categoriaRepositoory;
    private IGeneroRepository _generoRepository;
    private ICastFilmeRepository _castFilmeRepository;

    public ListVideo(IVideoRespository videoRespository,
    ICategoriaRepository categoriaRepositoory,
    IGeneroRepository generoRepository,
    ICastFilmeRepository castFilmeRepository)
    {
        _videoRespository = videoRespository;
        _categoriaRepositoory = categoriaRepositoory;
        _generoRepository = generoRepository;
        _castFilmeRepository = castFilmeRepository;
    }

    public async Task<ListVideoOutput> Handle(ListVideoInput request, CancellationToken cancellationToken)
    {
        var result = await _videoRespository.Search(new Interface.SearchRepository.SearchInput(
            request.pagina,
            request.perPagina,
            request.pesquisa,
            request.ordernacao,
            request.order
        ), cancellationToken);

        List<int> categoriasId = result.Itens.SelectMany(i => i.Categorias).ToList();
        List<int> generosId = result.Itens.SelectMany(i => i.Generos).ToList();
        List<int> castId = result.Itens.SelectMany(i => i.CastsFilme).ToList();

        List<Catalogo.Domain.Entity.Categoria>? categorias = null;
        if(categoriasId.Any())
            categorias = await _categoriaRepositoory.ListPorIds(categoriasId, cancellationToken);


        List<Catalogo.Domain.Entity.Genero> generos = null;
        if(generosId.Any())
            generos = await _generoRepository.ListPorIds(generosId, cancellationToken);

        List<Catalogo.Domain.Entity.CastFilme> cast = null;
        if(castId.Any())
            cast = await _castFilmeRepository.ListPorIds(castId, cancellationToken);


        var output = new ListVideoOutput(
            result.paginaAtual,
            result.Quantidade,
            result.Total,
            result.Itens.Select<Domain.Entity.Video, VideoModelOutput>(MapVideoToOutput(categorias,generos,cast)).ToList()
        );

        return output;
    }

    private Func<Domain.Entity.Video, VideoModelOutput> MapVideoToOutput(List<Catalogo.Domain.Entity.Categoria>? categorias, List<Catalogo.Domain.Entity.Genero> generos, List<Catalogo.Domain.Entity.CastFilme> cast)
    {
        return i => new VideoModelOutput(
            i.idGuid,
            i.Titulo,
            i.Descricao,
            i.AnoLancamento,
            i.Duracao,
            categorias?.Select(c => new RelatedAgreggation(c.idGuid, c.Nome)).ToList() ?? null,
            generos?.Select(g => new RelatedAgreggation(g.idGuid, g.Nome)).ToList() ?? null,
            cast?.Select(c => new RelatedAgreggation(c.idGuid, c.Nome)).ToList() ?? null,
            i.Thumb?.caminho, i.banner?.caminho,
            i.Media?.CaminhoArquivo, 
            i.ThumbHalf?.caminho,
            i.Trailer?.CaminhoArquivo);
    }
}
