using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto.Comment
{
    public record class CommentDto
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "This field is required"), StringLength(100)]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
