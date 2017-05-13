using System;

namespace Web.Models.ViewModels
{
    public abstract class BaseViewModelEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string Creator { get; set; }
    }
}