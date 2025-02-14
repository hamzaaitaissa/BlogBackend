using System.ComponentModel.DataAnnotations;

namespace blogfolio.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string HashedPassword { get; set; }

        public ICollection<Blog> Blogs { get; set; }

    }
}
