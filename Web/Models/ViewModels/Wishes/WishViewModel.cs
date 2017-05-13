using System;
using System.Collections.Generic;

namespace Web.Models.ViewModels.Wishes
{
    public class WishViewModel : BaseViewModelEntity<int>
    {
        public string Content { get; set; }
        public virtual IEnumerable<Comments.CommentViewModel> Comments { get; set; }
    }
}