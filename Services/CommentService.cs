using blogfolio.Dto;
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

        Task ICommentService.DeleteCommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Comment>> ICommentService.GetAllCommentAsync()
        {
            throw new NotImplementedException();
        }

        Task<Comment> ICommentService.GetCommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task ICommentService.UpdateCommentAsync(CreateCommentDto createCommentDto)
        {
            throw new NotImplementedException();
        }
    }
}
