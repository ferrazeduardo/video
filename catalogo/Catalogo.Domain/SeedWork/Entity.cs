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

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;


        var entity = (Entity)obj;
        return idGuid == entity.idGuid;
    }

}
