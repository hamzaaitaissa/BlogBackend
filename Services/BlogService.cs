using blogfolio.Data;
using blogfolio.Dto;
using blogfolio.Entities;
using blogfolio.Repositories;

namespace blogfolio.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        async Task<Blog> IBlogService.CreateBlogAsync(CreateBlogDto createBlogDto)
        {
            var blog = new Blog
            {
                Title = createBlogDto.Title,
                Description = createBlogDto.Description,
                UserId = createBlogDto.UserId,
                ImagePath = createBlogDto.ImagePath,
            };
            return await _blogRepository.AddAsync(blog);
        }

        async Task IBlogService.DeleteBlogAsync(int id)
        {
             await _blogRepository.DeleteAsync(id);
        }

        async Task<IEnumerable<Blog>> IBlogService.GetAllBlogsAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        Task<Blog> IBlogService.GetBlogById(int id)
        {
            return _blogRepository.GetAsync(id);
        }

        Task IBlogService.UpdateBlogAsync(CreateBlogDto createBlogDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
