using System.ComponentModel.DataAnnotations;

namespace blogfolio.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }

    }
}
