namespace MenuService.DTO
{
    public class WorkCenterForDashboardDTO
    {
        public int WorkcenterId { get; set; }
        public string WorkCenterCode { get; set; }
        public int Completed { get; set; }
        public int InProgress { get; set; }
        public int NotStarted { get; set; }
    }
}
