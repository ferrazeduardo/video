using System;

namespace Catalogo.Domain.SeedWork;

public interface IDomainEventPublisher
{
    Task PublishAsync(DomainEvent evento)  ;
}
