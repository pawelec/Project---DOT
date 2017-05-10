namespace Web.Models.ViewModels
{
    public abstract class BaseViewModelEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}