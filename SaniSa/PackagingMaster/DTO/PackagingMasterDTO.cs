using Common.DTO;

namespace PackagingMaster.DTO
{
    public class PackagingMasterDTO : PaginationDTO
    {
        public int PackagingId { get; set; }
        public string? PCode { get; set; }
        public string? PName { get; set; }
        public string? PDesc { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class PackagingMasterList
    {
        public IEnumerable<PackagingMasterDTO> Items { get; set; }
    }
}
