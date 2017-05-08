using Domain.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Contexts
{
    public class Context : IdentityDbContext<User>
    {
        public Context()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static Context Create()
        {
            return new Context();
        }
    }
}