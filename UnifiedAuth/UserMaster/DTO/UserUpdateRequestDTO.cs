namespace UserMaster.DTO
{
    public class UserUpdateRequestDTO
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? Designation { get; set; }
        public int IsActive { get; set; }
        public string? ProfileImage { get; set; }
        public string? ActionUser { get; set; }
    }
}
