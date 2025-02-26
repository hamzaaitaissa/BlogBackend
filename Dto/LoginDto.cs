namespace blogfolio.Dto
{
    public record class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }   
    }
}
