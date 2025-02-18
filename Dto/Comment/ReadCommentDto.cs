using blogfolio.Entities;
using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto.Comment
{
    public record class ReadCommentDto
    {
        
        public string Text { get; set; }
        
        public int UserId { get; set; }
    }
}
