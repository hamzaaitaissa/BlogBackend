using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto.Blog
{
    public class UpdateBlogDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }

        // List of selected tag IDs
        public List<int> TagIds { get; set; }
    }
}
