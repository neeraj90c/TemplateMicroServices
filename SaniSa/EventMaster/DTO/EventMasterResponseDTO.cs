namespace EventMaster.DTO
{
    public class EventMasterResponseDTO
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventCode { get; set; }
        public string? EventDesc { get; set; }
        public int CompanyId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? ActionUser { get; set; }

    }
    public class EventList
    {
        public IEnumerable<EventMasterResponseDTO>? List { get; set; }
    }
}
