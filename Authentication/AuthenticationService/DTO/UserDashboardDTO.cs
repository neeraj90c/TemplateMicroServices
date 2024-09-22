namespace AuthenticationService.DTO
{
    public class UserDashboardDTO
    {
        public string LabelName { get; set; }
        public string LabelValue { get; set; }
        public string LabelType { get; set; }
        public int ActionUser { get; set; }
    }
    public class UserDashboardList
    {
        public IEnumerable<UserDashboardDTO> UserDashboardDetails { get; set; }
    }
}
