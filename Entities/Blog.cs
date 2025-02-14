using System.ComponentModel.DataAnnotations;

namespace blogfolio.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
