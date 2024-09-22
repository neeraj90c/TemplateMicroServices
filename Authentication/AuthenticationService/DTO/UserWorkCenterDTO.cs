using Common.DTO;

namespace AuthenticationService.DTO
{
    public class UserWorkCenterDTO : PaginationDTO
    {
        public string WorkCenterName { get; set; }
        public int UserWorkCenterId { get; set; }
        public int UserId { get; set; }
        public int WorkCenterId { get; set; }
        public int IsActive { get; set; }
        public int ActionUser { get; set; }
        public int IsDeleted { get; set; }

    }

    public class UserWorkCenterList
    {
        public IEnumerable<UserWorkCenterDTO> UserWorkCenter { get; set; }
    }
}
