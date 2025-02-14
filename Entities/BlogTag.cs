using System.ComponentModel.DataAnnotations;

namespace blogfolio.Entities
{
    public class BlogTag
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
