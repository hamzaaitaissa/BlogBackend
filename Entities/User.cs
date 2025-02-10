using System.ComponentModel.DataAnnotations;

namespace blogfolio.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8)]
        public string HashedPassword { get; set; }
    }
}
