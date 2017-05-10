namespace Domain.Models.Wishes
{
    public class Wish : Entity<int>
    {
        public string Content { get; set; }
        public virtual Users.User Creator { get; set; }
    }
}
