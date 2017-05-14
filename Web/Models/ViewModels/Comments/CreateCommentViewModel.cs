using System;
using System.ComponentModel.DataAnnotations;
using Web.Attributes;

namespace Web.Models.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Treść jest wymagana!")]
        [StringNullOrWhitespaceValidation]
        public string Content { get; set; }
        public DateTime Created = DateTime.UtcNow;
        [Required, Range(1, int.MaxValue, ErrorMessage = "Id musi być większe od 0!")]
        public int WishId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Creator { get; set; }
    }
}