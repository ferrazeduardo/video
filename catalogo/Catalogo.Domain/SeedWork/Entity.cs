using System;

namespace Catalogo.Domain.SeedWork;
//padrao seeadwork
public abstract class Entity
{
    protected Entity()
    {
        this.idGuid = Guid.NewGuid();
    }

    public int id { get; protected set; }
    public Guid idGuid { get; protected set; }

    public void SetIdGuid(Guid idGuid)
    {
        this.idGuid = idGuid;
    }   
    
}
