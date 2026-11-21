using System;
using Catalogo.Domain.Events;
using Catalogo.Domain.Interface;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Application.EventHandlers;

public class SendToEncoderEventHandler : IDomainEventHandler<VideoUploadedEvent>
{
    private readonly IMessageProducer _messageProducer;
    public SendToEncoderEventHandler(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public async Task HandlerAsync(VideoUploadedEvent evento, CancellationToken cancellationToken = default)
    {
       await _messageProducer.SendMessageAsync(evento,cancellationToken);
    }
}
