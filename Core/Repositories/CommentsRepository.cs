using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Comments;
using System.Linq.Expressions;
using Core.Contexts;
using System.Data.Entity;
namespace Core.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {

        protected readonly Context _Context;

        public CommentsRepository(Context context)
        {
            this._Context = context;
        }

        public int Create(Comment entity)
            => (this._Context.Comments.Add(entity)).Id;

        public Comment Get(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> Get(Expression<Func<Comment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> Get()
            => this._Context.Comments.Include(comment => comment.Wish).ToList();
    }
}
