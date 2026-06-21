using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddGenero;

public class VincularGenero : IRequestHandler<AddGeneroInput, AddGeneroOutput>
{
    private IVideoRespository _videoRespository;
    private IGeneroRepository _generoRepository;
    private IUnitOfWork _unitOfWork;

    public VincularGenero(IVideoRespository videoRespository, IGeneroRepository generoRepository, IUnitOfWork unitOfWork)
    {
        _videoRespository = videoRespository;
        _generoRepository = generoRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<AddGeneroOutput> Handle(AddGeneroInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRespository.Get(x => x.idGuid == request.idVideo, cancellationToken);
        var genero = await _generoRepository.Get(x => x.idGuid == request.idVideo, cancellationToken);

        NotFoundException.IsNull(video, "Video não existe");
        NotFoundException.IsNull(genero, "Genero não existe");

        video.AddGenero(genero.id, genero.idGuid);
        await _unitOfWork.Commit(cancellationToken);

        return new AddGeneroOutput();

    }
}
