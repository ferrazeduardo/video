using System;

namespace Catalogo.Domain.SeedWork;

public class AggregationRoot : Entity
{

    private readonly List<DomainEvent> _eventos  = [];
    public IReadOnlyCollection<DomainEvent> Eventos => _eventos.AsReadOnly();   
    public AggregationRoot() : base()
    {
    }

    public void AddEvent(DomainEvent evento)
    {
        _eventos.Add(evento);
    }

    public void ClearEvents()
    {
        _eventos.Clear();
    }
}
