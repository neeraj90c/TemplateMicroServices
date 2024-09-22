namespace QuoteDetail.DTO
{
    public class QuoteDetailCreateRequestDTO
    {
        public int QuotId { get; set; }
        public int IDetailId { get; set; }
        public int IDetailType { get; set; }
        public decimal IMRP { get; set; }
        public decimal IPrice { get; set; }
        public string? IDesc { get; set; }
        public string? ActionUser { get; set; }

    }
}
