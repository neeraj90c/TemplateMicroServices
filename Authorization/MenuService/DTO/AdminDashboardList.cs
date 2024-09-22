namespace MenuService.DTO
{
    public class AdminDashboardList
    {
        public IEnumerable<DashboardHeaderDTO> DashboardList { get; set; }
        public IEnumerable<WorkCenterForDashboardDTO> WorkCenterList { get; set; }
        public IEnumerable<UserPerformanceForDashboardDTO> PerformanceList { get; set; }
        public IEnumerable<ActivePagesForDashboardDTO> ActivePagesList { get; set; }
        public IEnumerable<RoleDetailsForDashboardDTO> ActiveRolesList { get; set; }
    }
}
