using AutoMapper;
using blogfolio.Dto.Comment;
using blogfolio.Entities;
using blogfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogfolio.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public async Task<ActionResult<Comment>> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var comment = await _commentService.CreateCommentAsync(createCommentDto);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }
        public async Task<ActionResult<Task>> GetComment(int id)
        {
            var comment = await _commentService.GetCommentAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = await _commentService.GetAllCommentAsync();
            return Ok(comments);
        }
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return Ok();
        }
    }
}
