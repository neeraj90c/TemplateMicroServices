namespace QuoteDetail.DTO
{
    public class QuoteDetailUpdateRequestDTO
    {
        public int DetailId { get; set; }
        public int QuotId { get; set; }
        public int IDetailId { get; set; }
        public int IDetailType { get; set; }
        public decimal IMRP { get; set; }
        public decimal IPrice { get; set; }
        public string? IDesc { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
