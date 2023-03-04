using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;

[Serializable]
public abstract class Entity<T>
{
    public virtual T? Id { get; set; }
}

[Serializable]
public abstract class Entity : Entity<int>
{
}
