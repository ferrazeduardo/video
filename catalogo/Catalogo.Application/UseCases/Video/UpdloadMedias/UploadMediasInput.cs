using Catalogo.Application.UseCases.Video.Common;
using MediatR;

namespace Catalogo.Application.UseCases.Video.UpdloadMedias;

public record UploadMediasInput(int idVideo, ArquivoInput? arquivoVideo, ArquivoInput? trailerInput) : IRequest;
