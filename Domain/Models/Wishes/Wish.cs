using Domain.Models.Comments;
using System.Collections.Generic;

namespace Domain.Models.Wishes
{
    public class Wish : Entity<int>
    {
        public string Content { get; set; }
        public virtual Users.User Creator { get; set; }
        //public virtual ICollection<Comment> Comments {get;set;}

        public Wish()
        {
            //this.Comments = new HashSet<Comment>();
        }
    }
}
