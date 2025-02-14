﻿using blogfolio.Data;
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
                BlogTags = new List<BlogTag>()
            };
            // For each selected tag ID, create a new BlogTag entry
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
            await _blogRepository.AddAsync(blog);
            return blog;
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
