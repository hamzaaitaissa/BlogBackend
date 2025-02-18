using blogfolio.Entities;
using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto
{
    public record class ReadCommentDto
    {
        [Required(ErrorMessage ="This field is required"), StringLength(100)]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
