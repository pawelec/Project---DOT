using System;

namespace Web.Models.ViewModels.Wishes
{
    public class WishViewModel : BaseViewModelEntity<int>
    {
        public string Content { get; set; }
        public DateTime Created { get; set; }
        //public string Creator { get; set; }
    }
}