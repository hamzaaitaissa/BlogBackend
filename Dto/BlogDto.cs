﻿using System.ComponentModel.DataAnnotations;

namespace blogfolio.Dto
{
    public record class BlogDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required"), StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<string> Tags { get; set; }

    }



}
