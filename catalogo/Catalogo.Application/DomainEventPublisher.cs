using System;
using Catalogo.Domain.SeedWork;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.Application;

public class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task PublishAsync<TDomainEvent>(TDomainEvent evento,CancellationToken cancellationToken) where TDomainEvent : DomainEvent
    {
        var handlers = _serviceProvider.GetService<List<IDomainEventHandler<TDomainEvent>>>();
        if (handlers is null || handlers.Any() is false) return;

        foreach (var handler in handlers)
        {
            await handler.HandlerAsync(evento);
        }
    }
}
