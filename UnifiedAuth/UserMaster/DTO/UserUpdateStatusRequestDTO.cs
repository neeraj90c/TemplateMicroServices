namespace UserMaster.DTO
{
    public class UserUpdateStatusRequestDTO
    {
        public int UserId { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
