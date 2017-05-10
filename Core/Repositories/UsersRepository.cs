using Domain.Interfaces;
using System.Linq;
using Domain.Models.Users;

namespace Core.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        protected readonly Contexts.Context _context;

        public UsersRepository(Contexts.Context context)
        {
            this._context = context;
        }
        public User Get(string identityName)
        {
                return this._context.Users.FirstOrDefault(user => user.UserName == identityName);
        }
    }
}
