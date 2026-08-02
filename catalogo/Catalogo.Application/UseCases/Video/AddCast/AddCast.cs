using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;
using AppDomain = Catalogo.Domain.Entity;

namespace Catalogo.Application.UseCases.Video.AddCast;

public class AddCast : IRequestHandler<AddCastInput, AddCastOutput>
{
    private IUnitOfWork _unitOfWork;
    private IVideoCastFilmeRepository _videoCastFilmeRepository;
    private IVideoRespository _videoRespository;
    private ICastFilmeRepository _castFilmeRepository;

    public AddCast(
        IUnitOfWork unitOfWork,
        IVideoCastFilmeRepository videoCastFilmeRepository,
        IVideoRespository videoRespository,
        ICastFilmeRepository castFilmeRepository)
    {
        _unitOfWork = unitOfWork;
        _videoCastFilmeRepository = videoCastFilmeRepository;
        _videoRespository = videoRespository;
        _castFilmeRepository = castFilmeRepository;
    }

    public async Task<AddCastOutput> Handle(AddCastInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRespository.Get(x => x.id == request.idVideio, cancellationToken);
        var casts = await _castFilmeRepository.ListPorIds(request.idCastFilme, cancellationToken);

        NotFoundException.IsNull(video, "Vídeo não Existe");
        ValidacaoAddCast(request, casts);

        foreach (var cast in casts)
        {
            var videCastFilme = new VideoCastFilme(video.id, cast.id);
            await _videoCastFilmeRepository.Create(videCastFilme, cancellationToken);
        }
        await _unitOfWork.Commit(cancellationToken);

        return new AddCastOutput();
    }


    public void ValidacaoAddCast(AddCastInput request, List<AppDomain.CastFilme> castFilmes)
    {
        if (request.idCastFilme.Count > castFilmes.Count)
        {
            var idsNaoEncontrados = request.idCastFilme.Where(id => castFilmes.Any(cast => cast.id == id) is false).ToList();
            throw new ArgumentException("Casts não encontrados: " + string.Join(',', idsNaoEncontrados.ToString()));
        }
    }
}
