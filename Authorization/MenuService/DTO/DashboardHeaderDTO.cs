namespace MenuService.DTO
{
    public class DashboardHeaderDTO
    {
        public int ProblemsReported { get; set; }
        public int Resolved { get; set; }
        public TimeSpan ETATime { get; set; }
        public int ActiveTravelers { get; set; }
        public int ActiveWorkOrders { get; set; }
        public float AverageDelay { get; set; }

    }
}
