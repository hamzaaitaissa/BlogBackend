using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto
{
    public class CreateBlogDto
    {
        [Required(ErrorMessage = "This field is required"), StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
        public string ImagePath { get; set; }
    }
}
