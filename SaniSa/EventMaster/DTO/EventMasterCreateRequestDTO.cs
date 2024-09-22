using System.ComponentModel.Design;

namespace EventMaster.DTO
{
    public class EventMasterCreateRequestDTO
    {
        public string? EventName {get; set;}
	    public string? EventCode {get; set;}
	    public string? EventDesc { get; set; }
	    public int CompanyId { get; set; }
        public string? ActionUser { get; set; }
    }
}
