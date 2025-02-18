using AutoMapper;
using blogfolio.Dto.Blog;
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
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            var blogs = await _blogService.GetAllBlogsAsync();
            var responseDtos = _mapper.Map<IEnumerable<BlogResponseDto>>(blogs);
            return Ok(responseDtos);
         
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blog = await _blogService.CreateBlogAsync(createBlogDto);
            // Returns a 201 Created response with a route to the newly created blog post
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Blog>> UpdateBlog(int id,[FromBody] UpdateBlogDto updateBlogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _blogService.UpdateBlogAsync(updateBlogDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            await _blogService.DeleteBlogAsync(id);
            return Ok();
        }

    }
}
