namespace blogfolio.Dto.User
{
    public record class UserWithBlogsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<int>? BlogIds { get; set; }
    }
}
