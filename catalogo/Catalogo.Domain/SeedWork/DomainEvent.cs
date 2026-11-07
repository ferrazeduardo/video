using System;

namespace Catalogo.Domain.SeedWork;

public abstract class DomainEvent
{
    public DateTime DH_EVENT { get; private set; }

    protected DomainEvent()
    {
        DH_EVENT = DateTime.UtcNow;
    }
}
