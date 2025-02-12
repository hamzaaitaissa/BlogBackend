using blogfolio.Data;
using blogfolio.Dto;
using blogfolio.Entities;
using blogfolio.Repositories;

namespace blogfolio.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
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
            // If the DTO contains tag IDs, create join entities for each
            if (createBlogDto.TagIds != null)
            {
                foreach (var tagId in createBlogDto.TagIds)
                {
                    blog.BlogTags.Add(new BlogTag
                    {
                        TagId = tagId
                        // Note: BlogId will be set automatically by EF Core when the Blog entity is saved.
                    });
                }
            }
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
