using Common.DTO;

namespace UserMaster.DTO
{
    public class UserDTO:PaginationDTO
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
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsDeleted { get; set; }
        public string? ProfileImage { get; set; }
        public string? ActionUser { get; set; }
    }
    public class UserList
    {
        public IEnumerable<UserDTO> Items { get; set; }
    }
}
