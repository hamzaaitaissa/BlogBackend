using blogfolio.Dto.Comment;
using blogfolio.Entities;
using blogfolio.Repositories;

namespace blogfolio.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            
        }
        async Task<Comment> ICommentService.CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var comment = new Comment
            {
                Text = createCommentDto.Text,
                UserId = createCommentDto.UserId,
            };
            await _commentRepository.CreateAsync(comment);
            return comment;
        }

        async Task ICommentService.DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        async Task<IEnumerable<Comment>> ICommentService.GetAllCommentAsync()
        {
            return await _commentRepository.GetAllAsync();
        }

        async Task<Comment> ICommentService.GetCommentAsync(int id)
        {
            return await _commentRepository.GetByIdAsync(id);
        }

        Task ICommentService.UpdateCommentAsync(int id,UpdateCommentDto createCommentDto)
        {
            throw new NotImplementedException();
        }
    }
}
