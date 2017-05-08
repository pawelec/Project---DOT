using System;

namespace Domain.Models
{
    public class Entity<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual DateTime Created { get; set; }
    }
}
