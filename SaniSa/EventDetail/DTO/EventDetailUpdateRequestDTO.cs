namespace EventDetail.DTO
{
    public class EventDetailUpdateRequestDTO
    {
        public int EDetailId { get; set; }
        public int EventId { get; set; }
        public int ItemId { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }

    }
}
