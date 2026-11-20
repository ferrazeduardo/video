using System;

namespace Catalogo.Domain.SeedWork;

public interface IDomainEventPublisher
{
    Task PublishAsync<TDomainEvent>(TDomainEvent evento,CancellationToken cancellationToken) where TDomainEvent : DomainEvent;
}
