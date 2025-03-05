namespace blogfolio.Dto.User
{
    public class CreateUserDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}

