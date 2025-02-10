using blogfolio.Dto;
using blogfolio.Entities;

namespace blogfolio.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogById(int id);
        Task<Blog> CreateBlogAsync(CreateBlogDto createBlogDto);
        Task DeleteBlogAsync(int id);
        Task UpdateBlogAsync(CreateBlogDto createBlogDto, int id);
    }
}
