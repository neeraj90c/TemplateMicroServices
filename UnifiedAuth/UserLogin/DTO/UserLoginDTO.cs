namespace UserLogin.DTO
{
    public class UserLoginDTO
    {
        public int LoginId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public int FailedLoginAttempt { get; set; }
        public DateTime? LastLoggedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class UserLoginList
    {
        public IEnumerable<UserLoginDTO> Items { get; set; }
    }
    public class ValidationResponse
    {
        public string? ResponseMsg { get; set; }
        public int ResponseCode { get; set; }
    }
}
