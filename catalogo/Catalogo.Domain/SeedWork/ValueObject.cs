using System;

namespace Catalogo.Domain.SeedWork;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract bool Equals(ValueObject? other);
}
