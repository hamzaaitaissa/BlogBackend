using blogfolio.Dto.Comment;
using blogfolio.Entities;

namespace blogfolio.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllCommentAsync();
        Task<Comment> GetCommentAsync(int id);
        Task<Comment> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(int id,UpdateCommentDto createCommentDto);
        Task DeleteCommentAsync(int id);


    }
}
