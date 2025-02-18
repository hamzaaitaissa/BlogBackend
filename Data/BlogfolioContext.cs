using blogfolio.Entities;
using Microsoft.EntityFrameworkCore;

namespace blogfolio.Data
{
    public class BlogfolioContext(DbContextOptions<BlogfolioContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> blogTags { get; set; }
        public DbSet<Comment> comments { get; set; }

        // Configure the model relationships
        // This method is called by EF Core during model creation. 
        // It allows you to configure the model (entities, relationships, keys, etc.) using the Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite primary key for BlogTag (ensures each Blog-Tag pair is unique)
            modelBuilder.Entity<BlogTag>()
                .HasKey(bt => new { bt.BlogId, bt.TagId });

            modelBuilder.Entity<Blog>()
                .HasOne(b => b.User)          // Each Blog has one User
                .WithMany(u => u.Blogs)       // Each User can have many Blogs
                .HasForeignKey(b => b.UserId); // The foreign key property in Blog


            // Configure the relationship between Blog and BlogTag
            modelBuilder.Entity<BlogTag>()
                .HasOne(bt => bt.Blog)
                .WithMany(b => b.BlogTags)
                .HasForeignKey(bt => bt.BlogId)
                .OnDelete(DeleteBehavior.Cascade); ;

            // Configure the relationship between Tag and BlogTag
            modelBuilder.Entity<BlogTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BlogTags)
                .HasForeignKey(bt => bt.TagId)
                .OnDelete(DeleteBehavior.Cascade); ;
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Technology" },
                new Tag { Id = 2, Name = "Lifestyle" },
                new Tag { Id = 3, Name = "Programming" },
                new Tag { Id = 4, Name = "Travel" },
                new Tag { Id = 5, Name = "Food" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Hamza", Email = "Hamza@test.com", HashedPassword = "123456789" }
    );
            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Title = "Blog Title", Description = "Blog desc", UserId = 1, ImagePath = "cool.jpg", CreatedDate = new DateTime() }
                );
            modelBuilder.Entity<Blog>()
            .Property(b => b.CreatedDate)
            .HasDefaultValueSql("DATETIME('now')")
            .ValueGeneratedOnAdd();
        }
    }
}
