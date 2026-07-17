using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;
using domain = Catalogo.Domain.Entity;

namespace Catalogo.Application.UseCases.Video.Update;

public class UpdateVideo : IRequestHandler<UpdateVideoInput, UpdateVideoOutput>
{
    private IVideoRespository _videoRepository;
    private IUnitOfWork _unitOfWork;
    private IGeneroRepository _generoRepository;

    public UpdateVideo(IVideoRespository videoRepository, IUnitOfWork unitOfWork, IGeneroRepository generoRepository)
    {
        _videoRepository = videoRepository;
        _unitOfWork = unitOfWork;
        _generoRepository = generoRepository;
    }
    public async Task<UpdateVideoOutput> Handle(UpdateVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.idGuid == request.id, cancellationToken);
        NotFoundException.IsNull(video, "Video não encontrado");

        video.Update(request.titulo, request.descricao, request.anoLancamento, request.duracao, request.publicado, request.rating);
        await ValidacaoRelacao(request, video, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new UpdateVideoOutput();
    }

    private async Task ValidacaoRelacao(UpdateVideoInput request, domain.Video video, CancellationToken cancellationToken)
    {
        if ((request.generosIds?.Count ?? 0) > 0)
        {
            var generos = await ValidarGeneros(request, cancellationToken);

            generos.ForEach(g => video.AddGenero(g.id));
        }
    }


    private async Task<List<domain.Genero>> ValidarGeneros(UpdateVideoInput request, CancellationToken cancellationToken)
    {
        var generos = await _generoRepository.ListPorIds(request.generosIds, cancellationToken);

        if (generos.Count < request.generosIds.Count)
        {
            var generosNaoEncontrados = request.generosIds.Where(g => generos.Any(ge => ge.idGuid != g));
            throw new ArgumentException(" Generos não existem no sistema: " + string.Join(',', generosNaoEncontrados));
        }

        return generos;
    }
}
