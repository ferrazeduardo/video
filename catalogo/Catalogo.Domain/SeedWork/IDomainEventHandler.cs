using System;

namespace Catalogo.Domain.SeedWork;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : DomainEvent
{
    Task HandlerAsync(TDomainEvent evento, CancellationToken cancellationToken = default);
}
