using Domain.Interfaces;
using Domain.Models.Wishes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Contexts;
using System.Linq;
using Core.Extensions;
using System.Data.Entity;

namespace Core.Repositories
{
    public class WishesRepository : IWishesRepository
    {
        protected readonly Context _Context;

        public WishesRepository(Context context)
        {
            this._Context = context;
        }

        public Wish Get(int key) => this._Context.Wishes
            .Include(wish => wish.Comments)
            .FirstOrDefault(wish => wish.Id == key);

        public ICollection<Wish> Get(Expression<Func<Wish, bool>> predicate)
        {
            if (predicate.IsNull())
                return this._Context.Wishes
                    .Include(wish => wish.Comments)
                    .Include(wish => wish.Creator)
                    .Where(predicate).ToList();
            return new List<Wish>();
        }

        public ICollection<Wish> Get()
            => this._Context.Wishes
                .Include(wish => wish.Comments)
                .Include(wish => wish.Creator)
                .ToList();

        public int Create(Wish entity)
        {
            var id = (this._Context.Wishes.Add(entity).Id);
            //this._Context.Users.Attach(entity.Creator);
            this._Context.SaveChanges();
            return id;
        }
        public void Update(Wish wish)
        {
    
        }

        public bool Delete(Wish wish)
        {
            this._Context.Entry<Wish>(wish).State = EntityState.Deleted;
            return this._Context.SaveChanges() != 0 ? true : false;
        }
    }
}
