using AutoMapper;
using blogfolio.Dto.Blog;
using blogfolio.Entities;
using blogfolio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogfolio.Controllers
{
    [ApiController]
    [Route("api/Blog")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public BlogController(IBlogService blogService, IMapper mapper, IAuthorizationService authorizationService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _authorizationService = authorizationService;
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
            var responseDto = _mapper.Map<BlogResponseDto>(blog);
            return Ok(responseDto);
        }
        [Authorize(Roles = "Admin,Editor")]
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
        [Authorize(Roles = "Admin,Editor")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Blog>> UpdateBlog(int id,[FromBody] UpdateBlogDto updateBlogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _blogService.GetBlogById(id);

            var authTest = _authorizationService.AuthorizeAsync(User, blog, "BlogOwnerPolicy");
            if (authTest == null) return Forbid();

            await _blogService.UpdateBlogAsync(updateBlogDto, id);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            if (!ModelState.IsValid) {  return BadRequest(ModelState); }
            var blog = _blogService.GetBlogById(id);
            var authTest = _authorizationService.AuthorizeAsync(User, blog, "BlogOwnerPolicy");
            if (authTest == null) return Forbid();  
            await _blogService.DeleteBlogAsync(id);
            return Ok();
        }

    }
}
