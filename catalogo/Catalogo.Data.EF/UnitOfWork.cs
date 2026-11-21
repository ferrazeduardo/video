using System;
using Catalogo.Application.Interface;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Data.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly CatalogoDbContext _context;
    private readonly IDomainEventPublisher _domainEventPublisher;
    public UnitOfWork(CatalogoDbContext context, IDomainEventPublisher domainEventPublisher)
    {
        _context = context;
        _domainEventPublisher = domainEventPublisher;
    }
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }


    public async Task PublishDomainEvents(CancellationToken cancellationToken)
    {
        var aggregateRoots = _context.ChangeTracker
        .Entries<AggregationRoot>()
        .Where(e => e.Entity.Eventos.Any())
        .Select(e => e.Entity);

        var events = aggregateRoots.SelectMany(e => e.Eventos).ToList();

        foreach (var domainEvent in events)
        {
            await _domainEventPublisher.PublishAsync(domainEvent, cancellationToken);
        }
    }
}
