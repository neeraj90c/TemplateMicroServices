using Common.DTO;

namespace KitMaster.DTO
{
    public class KitMasterDTO : PaginationDTO
    {
        public int KitId { get; set; }
        public string? KCode { get; set; }
        public string? KName { get; set; }
        public string? KDescription { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class KitMasterList
    {
        public IEnumerable<KitMasterDTO> Items { get; set; }
    }
}
