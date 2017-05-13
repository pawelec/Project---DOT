namespace Domain.Models.Comments
{
    public class Comment : Entity<int>
    {
        public string Content { get; set; }
        public string Creator { get; set; }
        public virtual Wishes.Wish Wish { get; set; }
    }
}
