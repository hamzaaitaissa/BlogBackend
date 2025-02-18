using blogfolio.Dto.Comment;
using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto.Blog
{
    public record class BlogResponseDto
    {
        [Required(ErrorMessage = "This field is required"), StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<ReadCommentDto> Comments { get; set; }
    }
}
