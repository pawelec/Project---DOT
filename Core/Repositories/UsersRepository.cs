using Domain.Interfaces;
using System.Linq;
using Domain.Models.Users;

namespace Core.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        protected readonly Contexts.Context _context;

        public UsersRepository()
        {
            this._context = new Contexts.Context();
        }
        public User Get(string identityName)
        {
            using(var cxt = new Contexts.Context())
            {
                return cxt.Users.FirstOrDefault(user => user.UserName == identityName);
            }
        }
    }
}
