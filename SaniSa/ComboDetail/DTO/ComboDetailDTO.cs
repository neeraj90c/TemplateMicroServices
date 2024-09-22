using Common.DTO;

namespace ComboDetail.DTO
{
    public class ComboDetailDTO : PaginationDTO
    {
        public int DetailId { get; set; }
        public int ComboId { get; set; }
        public int ItemId { get; set; }
        public decimal? ItemPrice { get; set; }
        public decimal? Units { get; set; }
        public decimal? TotalAmt { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class ComboDetailList
    {
        public IEnumerable<ComboDetailDTO> Items { get; set; }
    }
}
