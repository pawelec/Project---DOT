using Domain.Models.Comments;

namespace Domain.Interfaces
{
    public interface ICommentsRepository : IRepository<int, Comment>
    {
    }
}
