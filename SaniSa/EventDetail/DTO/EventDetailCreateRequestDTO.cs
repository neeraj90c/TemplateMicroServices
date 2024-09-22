using System.ComponentModel.Design;

namespace EventDetail.DTO
{
    public class EventDetailCreateRequestDTO
    {
        public int EventId { get; set; }
        public int ItemId { get; set; }
	    public int CompanyId { get; set; }
        public string? ActionUser { get; set; }
    }
}
