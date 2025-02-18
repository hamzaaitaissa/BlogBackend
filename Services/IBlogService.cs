using blogfolio.Dto.Blog;
using blogfolio.Entities;

namespace blogfolio.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogById(int id);
        Task<Blog> CreateBlogAsync(CreateBlogDto createBlogDto);
        Task DeleteBlogAsync(int id);
        Task UpdateBlogAsync(UpdateBlogDto updateBlogDto, int id);
    }
}
