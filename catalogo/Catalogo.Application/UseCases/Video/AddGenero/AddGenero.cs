using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddGenero;

public class VincularGenero : IRequestHandler<AddGeneroInput, AddGeneroOutput>
{
    private IVideoRespository _videoRespository;
    private IGeneroRepository _generoRepository;
    private IUnitOfWork _unitOfWork;
    private IVideoGeneroReporisoty _videoGeneroReporisoty;

    public VincularGenero(
        IVideoRespository videoRespository,
        IGeneroRepository generoRepository,
        IUnitOfWork unitOfWork,
        IVideoGeneroReporisoty videoGeneroReporisoty)
    {
        _videoRespository = videoRespository;
        _generoRepository = generoRepository;
        _unitOfWork = unitOfWork;
        _videoGeneroReporisoty = videoGeneroReporisoty;
    }
    public async Task<AddGeneroOutput> Handle(AddGeneroInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRespository.Get(x => x.idGuid == request.idVideo, cancellationToken);
        var genero = await _generoRepository.Get(x => x.idGuid == request.idVideo, cancellationToken);

        NotFoundException.IsNull(video, "Video não existe");
        NotFoundException.IsNull(genero, "Genero não existe");

        var videoGenero = new VideoGenero(video.id, genero.id);

        await _videoGeneroReporisoty.Create(videoGenero, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new AddGeneroOutput();

    }
}
