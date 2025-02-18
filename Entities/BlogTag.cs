using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogfolio.Entities
{
    public class BlogTag
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
