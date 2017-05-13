using System;
using Web.Attributes;

namespace Web.Models.ViewModels.Wishes
{
    public class CreateWishViewModel
    {
        [StringNullOrWhitespaceValidation]
        public string Content { get; set; }
    }
}