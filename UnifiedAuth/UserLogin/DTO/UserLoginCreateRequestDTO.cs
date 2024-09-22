namespace UserLogin.DTO
{
    public class UserLoginCreateRequestDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? ActionUser { get; set; }

    }
}
