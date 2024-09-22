using Common.DTO;

namespace QuoteDetail.DTO
{
    public class QuoteDetailDTO : PaginationDTO
    {
        public int DetailId { get; set; }
        public int QuotId { get; set; }
        public int IDetailId { get; set; }
        public int IDetailType { get; set; }
        public decimal IMRP { get; set; }
        public decimal IPrice { get; set; }
        public string? IDesc { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class QuoteDetailList
    {
        public IEnumerable<QuoteDetailDTO> Items { get; set; }
    }
}
