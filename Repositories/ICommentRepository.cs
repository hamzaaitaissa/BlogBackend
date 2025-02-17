using blogfolio.Entities;

namespace blogfolio.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task CreateAsync(Comment comment);
    }
}
