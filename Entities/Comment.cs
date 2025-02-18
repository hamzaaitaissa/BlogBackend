using System.ComponentModel.DataAnnotations.Schema;

namespace blogfolio.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }  
    }
}
