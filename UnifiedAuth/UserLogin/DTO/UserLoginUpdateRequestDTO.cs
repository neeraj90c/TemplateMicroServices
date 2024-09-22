namespace UserLogin.DTO
{
    public class UserLoginUpdateRequestDTO
    {
        public int LoginId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
