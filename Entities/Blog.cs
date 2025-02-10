using System.ComponentModel.DataAnnotations;

namespace blogfolio.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
