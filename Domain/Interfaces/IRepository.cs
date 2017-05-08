using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey>
    {
        TEntity Get(TKey key);
        ICollection<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        ICollection<TEntity> Get();
    }
}
