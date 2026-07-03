using System;
using Catalogo.Application.Interface;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.Interface.Repository;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Delete;

public class DeleteVideo : IRequestHandler<DeleteVideoInput, DeleteVideoOutput>
{
    private IUnitOfWork _unitOfWork;
    private IVideoRespository _videoRepository;
    private IStorageService _storageService;

    public DeleteVideo(IUnitOfWork unitOfWork, IVideoRespository videoRepository, IStorageService storageService)
    {
        _unitOfWork = unitOfWork;
        _videoRepository = videoRepository;
        _storageService = storageService;
    }

    public async Task<DeleteVideoOutput> Handle(DeleteVideoInput request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.Get(x => x.id == request.id, cancellationToken);
        NotFoundException.IsNull(video, "Video não encontrado");

        await _videoRepository.Delete(video, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return new DeleteVideoOutput();
    }
}
