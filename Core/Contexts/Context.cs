using Domain.Models.Comments;
using Domain.Models.Users;
using Domain.Models.Wishes;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Core.Contexts
{
    public class Context : IdentityDbContext<User>
    {
        public virtual DbSet<Wish> Wishes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public Context()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static Context Create()
        {
            return new Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<Wish>()
                .HasMany(wish => wish.Comments)
                .WithRequired(comment => comment.Wish);

        }
    }
}