using Domain.Interfaces;
using Domain.Models.Wishes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Contexts;
using System.Linq;
using Core.Extensions;

namespace Core.Repositories
{
    public class WishesRepository : IWishesRepository
    {
        protected readonly Context _Context;

        public WishesRepository(Context context)
        {
            this._Context = context;
        }

        public Wish Get(int key) => this._Context.Wishes.Find(key);

        public ICollection<Wish> Get(Expression<Func<Wish, bool>> predicate)
        {
            if (predicate.IsNull())
                return this._Context.Wishes.Where(predicate).ToList();
            return new List<Wish>();
        }

        public ICollection<Wish> Get()
            => this._Context.Wishes.ToList();

        public int Create(Wish entity)
        {
            var id = (this._Context.Wishes.Add(entity).Id);
            //this._Context.Users.Attach(entity.Creator);
            this._Context.SaveChanges();
            return id;
        }
    }
}
