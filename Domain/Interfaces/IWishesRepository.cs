using Domain.Models.Wishes;

namespace Domain.Interfaces
{
    public interface IWishesRepository : IRepository<int, Wish>
    {
        void Update(Wish wish);
        bool Delete(Wish wish); 
    }
}
