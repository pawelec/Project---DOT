namespace Web.Models.ViewModels.Comments
{
    public class CommentViewModel : BaseViewModelEntity<int>
    {
        public string Content { get; set; }
        public int WishId { get; set; }
    }
}