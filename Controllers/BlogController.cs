using blogfolio.Dto;
using blogfolio.Entities;
using blogfolio.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogfolio.Controllers
{
    [ApiController]
    [Route("api/Blog")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            var blogs = await _blogService.GetAllBlogsAsync();
            return Ok(blogs);
         
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> CreateBlog([FromBody] CreateBlogDto createBlogDto)
        {
            var blog = await _blogService.CreateBlogAsync(createBlogDto);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog);
        }

    }
}
