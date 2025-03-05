namespace blogfolio.Dto.User
{
    public record class UpdateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
