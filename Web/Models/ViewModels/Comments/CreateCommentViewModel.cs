using System;
using Web.Attributes;

namespace Web.Models.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        [StringNullOrWhitespaceValidation]
        public string Content { get; set; }
        public DateTime Created = DateTime.UtcNow;
        public int WishId { get; set; }
        public string Creator { get; set; }
    }
}