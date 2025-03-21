﻿using blogfolio.Data;
using blogfolio.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace blogfolio.Repositories
{
    public class BlogRepository: IBlogRepository
    {
        private readonly BlogfolioContext _blogfolioContext;
        public BlogRepository(BlogfolioContext blogfolioContext)
        {
            _blogfolioContext = blogfolioContext;
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _blogfolioContext.Blogs.FindAsync(id);
            _blogfolioContext.Blogs.Remove(blog);
            await _blogfolioContext.SaveChangesAsync();
        }

        async Task<Blog> IBlogRepository.AddAsync(Blog blog)
        {
            await _blogfolioContext.Blogs.AddAsync(blog);
            await _blogfolioContext.SaveChangesAsync();
            return blog;
        }

        async Task<IEnumerable<Blog>> IBlogRepository.GetAllAsync()
        {
            var blogs =  await _blogfolioContext.Blogs
        .Include(b => b.User)
        .Include(b => b.Comments)
            .ThenInclude(c => c.User)
        .Include(b => b.BlogTags)
            .ThenInclude(bt => bt.Tag)
        .ToListAsync();

            return blogs;
        }

        async Task<Blog> IBlogRepository.GetAsync(int id)
        {
            var blog = await _blogfolioContext.Blogs.Include(b => b.BlogTags)
            .ThenInclude(bt => bt.Tag).Include(b => b.Comments).ThenInclude(c=> c.User).Include(b=>b.User)
        .FirstOrDefaultAsync(b => b.Id == id);
            return blog;
        }

        async Task IBlogRepository.UpdateAsync(Blog blog)
        {
            _blogfolioContext.Blogs.Update(blog);
            await _blogfolioContext.SaveChangesAsync();
        }
    }
}
