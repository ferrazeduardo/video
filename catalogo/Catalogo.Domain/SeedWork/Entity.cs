using System;

namespace Catalogo.Domain.SeedWork;
//padrao seeadwork
public abstract class Entity
{
    public int id { get; protected set; }

    public void SetId(int id)
    {
        this.id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;


        var entity = (Entity)obj;
        return id == entity.id;
    }

}
