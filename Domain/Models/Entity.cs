using System;

namespace Domain.Models
{
    public class Entity<TKey>
        where TKey : struct
    {
        public virtual TKey Id { get; set; }
        public virtual DateTime Created { get; set; }
    }
}
