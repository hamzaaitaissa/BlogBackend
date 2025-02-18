using blogfolio.Data;
using blogfolio.Entities;
using Microsoft.EntityFrameworkCore;

namespace blogfolio.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogfolioContext _blogfolioContext;
        public CommentRepository(BlogfolioContext blogfolioContext)
        {
            _blogfolioContext = blogfolioContext;
        }
        async Task<Comment> ICommentRepository.CreateAsync(Comment comment)
        {
            await _blogfolioContext.AddAsync(comment);
            await _blogfolioContext.SaveChangesAsync();
            return comment;
        }
        
        async Task ICommentRepository.DeleteAsync(int id)
        {
           var comment = await _blogfolioContext.comments.FindAsync(id);
            if(comment != null)
            {
                _blogfolioContext.comments.Remove(comment);
                await _blogfolioContext.SaveChangesAsync();
            }

        }

        async Task<IEnumerable<Comment>> ICommentRepository.GetAllAsync()
        {
            var comments = await _blogfolioContext.comments.ToListAsync();
            return comments;
        }

        async Task<Comment> ICommentRepository.GetByIdAsync(int id)
        {
            var comment = await _blogfolioContext.comments.FindAsync(id);
            return comment;
        }

        async Task ICommentRepository.UpdateAsync(Comment comment)
        {
             _blogfolioContext.comments.Update(comment);
            await _blogfolioContext.SaveChangesAsync();
        }
    }
}
