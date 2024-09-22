using Common.DTO;

namespace KitDetail.DTO
{
    public class KitDetailDTO : PaginationDTO
    {
        public int DetailId { get; set; }
        public int KitId { get; set; }
        public int ItemId { get; set; }
        public string? Remarks { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class KitDetailList
    {
        public IEnumerable<KitDetailDTO> Items { get; set; }
    }
}
