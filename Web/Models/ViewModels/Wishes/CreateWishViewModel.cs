using System;

namespace Web.Models.ViewModels.Wishes
{
    public class CreateWishViewModel
    {
        public string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}