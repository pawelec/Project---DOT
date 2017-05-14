using System;
using System.ComponentModel.DataAnnotations;
using Web.Attributes;

namespace Web.Models.ViewModels.Wishes
{
    public class CreateWishViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Treść jest wymagana!")]
        [StringNullOrWhitespaceValidation]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        public DateTime Created = DateTime.UtcNow;
    }
}