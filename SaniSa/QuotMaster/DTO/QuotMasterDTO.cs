using Common.DTO;

namespace QuotMaster.DTO
{
    public class QuotMasterDTO : PaginationDTO
    {
        public int QuotId { get; set; }
        public string? QName { get; set; }
        public string? QCode { get; set; }
        public string? QDesc { get; set; }
        public string? QStatus { get; set; }
        public DateTime? QDate { get; set; }
        public decimal? QRange { get; set; }
        public decimal? QMod { get; set; }
        public int ClientId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class QuotMasterList
    {
        public IEnumerable<QuotMasterDTO> Items { get; set; }
    }
}
